using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class SecondEnemyController : MonoBehaviour
{
    public float moveSpeed;
    public Transform wallCheck;
    public Transform groundCheck;
    public float wallDistance;
    public float groundDistance;
    public LayerMask groundLayer;
    public LayerMask wallLayer;
    public float visionAngle = 120f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Vector2 moveDirection;

    public Transform character;
    public float shootDistance;
    private bool isShooting;
    private Vector2 lastKnownPosition; // Son görülen konum
    private bool isSearching = false;
    private float searchTime = 1.5f;

    public GameObject bulletPref;
    public Transform firePoint;
    public float bulletSpeed;
    private float nextFireTime;
    private float fireRate = 1;
    public Transform eyePosition;
    public LayerMask obstacleLayer;

    private Animator animator;

    public ParticleSystem enemyDeathParticle;

    private bool isWalkingSoundPlaying = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        moveDirection = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if(character == null)
        {
            isShooting = false;
        }

        CharacterDistance();

        if(!isShooting)
        {
            CheckObstacleOrEdge();
            Move();
        }
        else
        {
            CharacterShoot();
        }

        
    }

    private void Move()
    {
       

        rb.velocity = new Vector2(moveDirection.x * moveSpeed,rb.velocity.y);
        if(animator != null)
        {
            animator.SetFloat("run", Mathf.Abs(rb.velocity.x));
        }

         
    }

    private void CheckObstacleOrEdge() 
    {
        RaycastHit2D wallHit = Physics2D.Raycast(wallCheck.position,moveDirection,wallDistance, wallLayer);
        RaycastHit2D groundHit = Physics2D.Raycast(groundCheck.position, Vector2.down, groundDistance, groundLayer);

        if(wallHit.collider != null || groundHit.collider == null)
        {
            Flip();
        } 
    }
    private void Flip()
    {
        moveDirection = -moveDirection;
        transform.localScale = new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);
    }

    private void OnDrawGizmosSelected()
    {
        if(wallCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(moveDirection * wallDistance));
        }
        if(groundCheck != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(groundCheck.position, groundCheck.position + (Vector3)(Vector2.down * groundDistance));
        }
        if(eyePosition != null && character != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(eyePosition.position, character.position);
        }
    }

    private void CharacterDistance()
    {
        if (character == null || eyePosition == null) return;

        float characterHeightOffset = 1.0f;
        Vector2 characterTargetPoint = new Vector2(character.position.x, character.position.y + characterHeightOffset);
        float distanceToCharacter = Vector2.Distance(eyePosition.position, characterTargetPoint);

        if (distanceToCharacter > shootDistance)
        {
            if (!isSearching)
            {
                StartCoroutine(SearchForPlayer());
            }
            return;
        }

        Vector2 directionToCharacter = (characterTargetPoint - (Vector2)eyePosition.position).normalized;
        Vector2 enemyForward = transform.localScale.x > 0 ? Vector2.right : Vector2.left;

        float dotProduct = Vector2.Dot(directionToCharacter, enemyForward);
        if (dotProduct < Mathf.Cos(visionAngle * Mathf.Deg2Rad * 0.5f))
        {
            if (!isSearching)
            {
                StartCoroutine(SearchForPlayer());
            }
            return;
        }

        RaycastHit2D hit = Physics2D.Raycast(eyePosition.position, directionToCharacter, shootDistance, obstacleLayer);
        if (hit.collider != null && !hit.collider.CompareTag("Player"))
        {
            if (!isSearching)
            {
                StartCoroutine(SearchForPlayer());
            }
            return;
        }

        // Oyuncu görünüyorsa son konumunu kaydet
        lastKnownPosition = character.position;
        isSearching = false;
        isShooting = true;
    }

    private void CharacterShoot()
    {
        if (character == null)
        {
            isShooting = false;
            return;
        }
        float direction = character.position.x - transform.position.x;
       // if (Mathf.Abs(direction) > 0.1f) 
        {
            if (direction < 0 && transform.localScale.x > 0)
            {
                Flip();
            }
            else if (direction > 0 && transform.localScale.x < 0)
            {
                Flip();
            }
        }
            

        rb.velocity = Vector2.zero;

        if(Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }

    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPref, firePoint.position, Quaternion.identity);
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();

        //  Merminin yönünü belirle (Karakterin pozisyonuna doðru)
        Vector2 shootDirection = (character.position - firePoint.position).normalized;

        // Mermiye yön ve hýz kazandýr**
        rbBullet.velocity = shootDirection * bulletSpeed;

        //  Mermi açýsýný karaktere yönlendirmek için döndür**
        float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0, 0, angle);
        //GameObject bullet = Instantiate(bulletPref, firePoint.position, firePoint.rotation);
        //Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();

        //float direction = transform.localScale.x > 0 ? 1 : -1;
        //rbBullet.velocity = new Vector2(direction * bulletSpeed, 0);

        AudioManager audioManager = FindObjectOfType<AudioManager>();
        Vector3 enemybulletPosition = transform.position;
        FindObjectOfType<AudioManager>().PlaySoundAtPosition("Shoot_Enemy", enemybulletPosition);

        //if (direction < 0)
        //{
        //    bullet.transform.rotation = Quaternion.Euler(0, 180, 0);
        //}

        animator.SetBool("isShooting", true);
        StartCoroutine(EnemyShootAnim());
    }

    private IEnumerator EnemyShootAnim()
    {
        yield return new WaitForSeconds(0.30f);
        animator.SetBool("isShooting", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            SecondEnemyDeath();
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SecondEnemyDeath();
        }
        if (collision.gameObject.CompareTag("rocket"))
        {
            SecondEnemyDeath();
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            SecondEnemyDeath();
        }
    }

    private IEnumerator SearchForPlayer()
    {
        isSearching = true;

        // Son görülen yere yönel
        float moveDirection = lastKnownPosition.x > transform.position.x ? 1 : -1;
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        yield return new WaitForSeconds(searchTime);

        // Eðer oyuncu hala görünmüyorsa devriye moduna dön
        isShooting = false;
        isSearching = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("deadzone"))
        {
            SecondEnemyDeath();
        }
    }

    private void SecondEnemyDeath()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();

       


        Vector3 enemydeathPosition = transform.position;
        FindObjectOfType<AudioManager>().PlaySoundAtPosition("Enemy_Death", enemydeathPosition);

        RangeEnemyDeathEffect();

        Destroy(gameObject);
       
    }

    private void RangeEnemyDeathEffect()
    {
        Instantiate(enemyDeathParticle, transform.position, Quaternion.identity);
    }
}
