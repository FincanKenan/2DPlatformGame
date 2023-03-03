using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MobileMovement : MonoBehaviour
{
    private Rigidbody2D fizik;
    private float y�r�meH�z� = 8;
    private float y�r�meY�n�;

    private bool zemindeMi;
    private float z�plamaG�c� = 8;
    public LayerMask zemin;
    private float checkRadius = 0.2f;
    public Transform z�plamaKontrol;

    private bool z�pl�yorMu;
    private float zamanSayac�;
    private float z�plamaS�resi = 0.35f;

    private int exJump;
    private int exjumpTime = 2;
    private float exZ�plamaG�c� = 12;

    public AudioSource y�r�meSesi;
    public AudioSource z�plamaSesi;
    public AudioSource exJumpSound;
    private bool y�r�yor = false;



    private Animator animator;
    void Start()
    {
        fizik = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        y�r�meY�n� = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        fizik.velocity = new Vector2(y�r�meH�z� * y�r�meY�n�, fizik.velocity.y);

        if (y�r�meY�n� < 0)
        {


            transform.eulerAngles = new Vector3(0, -180, 0);
        }
        else if (y�r�meY�n� > 0)
        {


            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        


        if (y�r�meY�n� == 0)
        {
            y�r�yor = false;
            animator.SetBool("Running", false);
        }
        else
        {
            animator.SetBool("Running", true);
        }

        
    }
    void Update()
    {

        zemindeMi = Physics2D.OverlapCircle(z�plamaKontrol.position, checkRadius, zemin);
        if (zemindeMi == true && CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            fizik.velocity = Vector2.up * z�plamaG�c�;

            z�pl�yorMu = true;
            zamanSayac� = z�plamaS�resi;
            y�r�yor = false;
            if (!z�plamaSesi.isPlaying)
            {
                z�plamaSesi.Play();
            }

        }
        else if (zemindeMi == false && CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            z�pl�yorMu = false;
        }

        if (z�pl�yorMu == true && CrossPlatformInputManager.GetButton("Jump"))
        {
            if (zamanSayac� > 0)
            {
                fizik.velocity = Vector2.up * z�plamaG�c�;
                zamanSayac� -= Time.deltaTime;
            }
            else
            {
                z�pl�yorMu = false;
            }

        }
        //---------  Y�R�MESES�  -------------

        if (zemindeMi == true && y�r�meY�n� != 0)
        {
            y�r�yor = true;
        }
        else if (zemindeMi == false && y�r�meY�n� != 0)
        {
            y�r�yor = false;
        }

        if (y�r�yor == true)
        {
            if (!y�r�meSesi.isPlaying)
            {
                y�r�meSesi.Play();
            }
        }
        else
        {
            y�r�meSesi.Stop();
        }



        //---------  Y�R�MESES�  -------------

        if (zemindeMi == false)
        {
            animator.SetBool("Jumping", true);
        }
        else
        {
            animator.SetBool("Jumping", false);
        }


        if (zemindeMi == true)
        {
            exJump = exjumpTime;
        }

        if (exJump > 0 && CrossPlatformInputManager.GetButtonDown("Jump") && z�pl�yorMu == false)
        {
            if (!exJumpSound.isPlaying)
            {
                exJumpSound.Play();
            }
            animator.SetBool("ExJump", true);
        }
        else if (zemindeMi == true)
        {
            animator.SetBool("ExJump", false);
        }


        if (CrossPlatformInputManager.GetButtonDown("Jump") && exJump > 0)
        {
            fizik.velocity = Vector2.up * exZ�plamaG�c�;
            exJump--;
        }





    }



}
