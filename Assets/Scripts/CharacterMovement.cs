using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    public Transform checkPosition;
    public LayerMask groundLayer;
    private float groundkRadius = 0.1f;
    private bool isGrounded;

    public float jumpForce;
    public float moveSpeed;

    private int jumpNumber = 1;
    private int jumpCount;

    public float jumpHoldForce;
    public float maxJumptime;
    private float jumpTimecounter;
    private bool isJumping;

    private Animator animator;

    [Header("Dash Settings")]
    public float dashSpeed;
    public float dashTime;
    public float dashCooldown;
    private bool isDashing = false;
    private bool canDash = true;
    private bool dashedInAir = false;
    private float defaultGravity;
    private float previusGravity;
   

    [Header("Wall Jump Settings")]
    public Transform wallCheck;
    public float wallDistance;
    public LayerMask wallMask;
    private bool isWalling;
    private bool isWallJumpActive = false;
    public GameObject sparkAnim;

    private bool isWallSliding = false;
    private bool canWallJump = false;
    public float wallJumpPush;
    public float wallSlideSpeed;

    private bool disabledInput = false;

    private bool wasGrounded; // Sound...

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        jumpCount = 0;
        animator = GetComponent<Animator>();
        defaultGravity = myRigidbody.gravityScale;

        if (sparkAnim != null)
        {
            sparkAnim.SetActive(false);
        }

    }


    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (!isDashing && !disabledInput)
        {
            myRigidbody.velocity = new Vector2(horizontal * moveSpeed, myRigidbody.velocity.y);  // Yürüme
        }

        AudioManager audioManager = FindObjectOfType<AudioManager>();
        Sound walkSound = Array.Find(audioManager.sounds, sound => sound.name == "PlayerMovement");
        Sound sparkSound = Array.Find(audioManager.sounds, sound => sound.name == "SparkEffect_Sound");

        if (walkSound != null)  // WALK SOUND
        {
            if (isGrounded && Mathf.Abs(horizontal) > 0.1f) // Hareket ediyorsa ve zemindeyse
            {
                if (!walkSound.source.isPlaying) // Ses zaten çalmýyorsa
                {
                    walkSound.source.Play();
                }
            }
            else
            {
                walkSound.source.Stop(); // Karakter durduðunda sesi kes
            }
        }

        if(!wasGrounded && isGrounded)
        {
            Sound groundSound = Array.Find(audioManager.sounds, sound => sound.name == "GroundedSound");

            if (groundSound != null)
            {
                groundSound.source.Play();
            }
        }

        wasGrounded = isGrounded;

        if (horizontal > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontal < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);   // Yürüme
        }

        isGrounded = Physics2D.OverlapCircle(checkPosition.position, groundkRadius, groundLayer);
        isWalling = Physics2D.OverlapCircle(wallCheck.position, wallDistance, wallMask);


        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        animator.SetBool("isJumping", !isGrounded);
        animator.SetInteger("JumpCount", jumpCount);


        if (isGrounded)
        {
            jumpCount = 0;
            animator.SetBool("isJumping", false);
            dashedInAir = false;
            isWallJumpActive = false;
            isWallSliding = false;
            canWallJump = false;
            disabledInput = false;
        }
        else
        {
            animator.SetBool("isJumping", true);
        }

        if (!isGrounded && isWalling && horizontal != 0 && !isDashing && !disabledInput)
        {
            if (!isWallSliding)
            {
                isWallSliding = true;
                canWallJump = true;
            }

            // Kayma efekti
            myRigidbody.velocity = new Vector2(0, -wallSlideSpeed);
            myRigidbody.gravityScale = 0.3f; // Düþüþü yavaþlat

            //  animator.SetBool("isWallSliding", true);

            if (sparkAnim != null)
            {
                sparkAnim.SetActive(true);

                
            }

            

            if (sparkSound != null)
            {
                sparkSound.source.Play();
            }
            if (sparkSound != null && !sparkSound.source.isPlaying)
            {
                sparkSound.source.Play();
            }

        }
        else
        {
            isWallSliding = false;
            if (!isDashing)
            {
                myRigidbody.gravityScale = defaultGravity;
            }
            //   animator.SetBool("isWallSliding", false);

            if (sparkAnim != null)
            {
               
                sparkAnim.SetActive(false);
            }
            if (sparkSound != null && sparkSound.source.isPlaying)
            {
                sparkSound.source.Stop();
            }

        }




        if (!isGrounded && isWalling && jumpCount >= jumpNumber)
        {
            isWallJumpActive= true;
            jumpCount = 1;
        }
        else
        {
            isWallJumpActive = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && !dashedInAir)
        {
            StartCoroutine(Dash());

            Sound dashSound = Array.Find(audioManager.sounds, sound => sound.name == "DashSound");
            if (!dashSound.source.isPlaying)
            {
                dashSound.source.Play();
            }

        }
        if(!isGrounded && isWalling && jumpCount >= jumpNumber)
        {
            isWallJumpActive = true;
            jumpCount = 0;
        }
        else
        {
            isWallJumpActive= false;
        }

        // Double Zýplama
        // Duvar Sýçramasý (Wall Jump)
        if (Input.GetKeyDown(KeyCode.Space) && (isWallJumpActive || isGrounded || jumpCount < jumpNumber))
        {
            if (isWallSliding) // Eðer duvara tutunuyorsa
            {
                float wallJumpDirection = transform.localScale.x > 0 ? -1 : 1; // Ters yöne it

                disabledInput = true; // Giriþleri engelle
                Invoke("EnableInput", 0.05f); // Çok kýsa bir süre sonra giriþleri aç

                // Duvar zýplamasý: Yukarý ve yatay yönde
                myRigidbody.velocity = new Vector2(wallJumpDirection * wallJumpPush + moveSpeed * Input.GetAxis("Horizontal"), jumpForce);
                transform.localScale = new Vector3(wallJumpDirection, 1, 1);

                isWallSliding = false; // Duvara yapýþmayý kapat
                canWallJump = false; // Tekrar yapýþmasýný engelle
                isWallJumpActive = false; // Duvar zýplamasý sýfýrlansýn
                jumpCount++;

                StartCoroutine(ReenableWallSlide()); // Bir süre sonra tekrar duvara tutunabilmesi için

                animator.SetInteger("JumpCount", jumpCount);
            }
            else // Normal çift zýplama
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x + moveSpeed * Input.GetAxis("Horizontal"), jumpForce);
                jumpCount++;
                Sound jumpSound = Array.Find(audioManager.sounds, sound => sound.name == "PlayerJump");
                if (!jumpSound.source.isPlaying)
                {
                    jumpSound.source.Play();
                }
            }

            isJumping = true;
            jumpTimecounter = maxJumptime;
            animator.SetInteger("JumpCount", jumpCount);
        }

        // Double Zýplama

        // Basýlý Tutarak Zýplama

        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (jumpTimecounter > 0)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, myRigidbody.velocity.y + jumpHoldForce * Time.deltaTime);
                jumpTimecounter -= Time.deltaTime;

                Sound secondjumpSound = Array.Find(audioManager.sounds, sound => sound.name == "PlayerJump");
                if (!secondjumpSound.source.isPlaying)
                {
                    secondjumpSound.source.Play();
                }
            }
            else
            {
                isJumping = false;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                isJumping = false;
                jumpTimecounter = 0;
            }

            
        }
        // Basýlý Tutarak Zýplama

    }

    private void EnableInput()
    {
        disabledInput = false;
    }


    private IEnumerator Dash()
    {
        isDashing = true;
        canDash = false;

        if (!isGrounded)
        {
            dashedInAir = true;
        }

        float previusGravity = myRigidbody.gravityScale;
        myRigidbody.gravityScale = 0f;
        myRigidbody.velocity = Vector2.zero; 
        myRigidbody.velocity = new Vector2(transform.localScale.x * dashSpeed, 0f);
        animator.SetBool("isDashAnim", true);


        yield return new WaitForSeconds(dashTime);

        myRigidbody.gravityScale = previusGravity;
        isDashing = false;

        animator.SetBool("isDashAnim", false);

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    private IEnumerator ReenableWallSlide()
    {
        yield return new WaitForSeconds(0.1f); // Kýsa bir bekleme süresi
        if (!isGrounded) // Eðer hala havadaysa ve tekrar duvara temas ettiyse
        {
            isWallSliding = true;
            canWallJump = true;
            isWallJumpActive = true;
        }
    }





    private void OnDrawGizmosSelected()
    {
        if (checkPosition != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(checkPosition.position,groundkRadius);
        }
    }
}
