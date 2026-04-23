using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed; // Normal hýz
    public float chaseSpeed; // Takip hýzý
    public float detectionDistance; // Algýlama mesafesi
    public float visionAngle = 360f; // Düþmanýn görüþ açýsý (derece)
    public LayerMask obstacleLayer; // Engel katmanlarý (duvar, obje vb.)

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Vector2 moveDirection;
    private bool isChasing = false;
    private Animator animator;

    public Transform character; // Takip edilecek karakter
    public Transform eyePosition; // Düþmanýn göz pozisyonu

    public Transform wallCheck; // Duvar kontrol noktasý
    public Transform groundCheck; // Zemin kontrol noktasý
    public Transform trapCheck;
    public float wallcheckDistance = 0.2f;
    public float groundCheckDistance = 0.2f;
    public float trapCheckDistance = 0.2f;
    public LayerMask wallLayer;
    public LayerMask groundLayer;
    public LayerMask trapLayer;

    public ParticleSystem enemyDeathParticle; // Düþman ölünce çýkan efekt

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        moveDirection = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
        animator = GetComponent<Animator>();

        // Eksik bileþen kontrolü
        if (rb == null) Debug.LogError("HATA: Rigidbody2D bileþeni eksik!", gameObject);
        if (animator == null) Debug.LogError("HATA: Animator bileþeni eksik!", gameObject);
        if (spriteRenderer == null) Debug.LogError("HATA: SpriteRenderer bileþeni eksik!", gameObject);
        if (eyePosition == null) Debug.LogError("HATA: eyePosition atanmadý!", gameObject);
        if (wallCheck == null) Debug.LogError("HATA: wallCheck atanmadý!", gameObject);
        if (groundCheck == null) Debug.LogError("HATA: groundCheck atanmadý!", gameObject);
    }

    void Update()
    {
        if (character == null)
        {
            isChasing = false;
            return;
        }

        DetectCharacter(); // Karakteri algýlama

        if (!isChasing)
        {
            Move();
            CheckObstacleOrEdge(); // Duvar veya boþluk kontrolü
        }
        else
        {
            ChaseCharacter();
        }

        animator.SetBool("ischracterRange", isChasing);
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
        animator.SetFloat("run", Mathf.Abs(rb.velocity.x));

       
    }

    private void Flip()
    {
        moveDirection *= -1;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    private void CheckObstacleOrEdge()
    {
        RaycastHit2D wallHit = Physics2D.Raycast(wallCheck.position, moveDirection, wallcheckDistance, wallLayer);
        RaycastHit2D groundHit = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);
        RaycastHit2D trapHit = Physics2D.Raycast(trapCheck.position, Vector2.down, trapCheckDistance, trapLayer);
        if (wallHit.collider != null || groundHit.collider == null || (trapHit.collider != null && trapHit.collider.CompareTag("trap")))
        {
            Flip();
        }
    }

    private void DetectCharacter()
    {
        if (character == null || eyePosition == null) return;

        float characterHeightOffset = 1.0f; // Karakterin algýlama noktasý biraz daha yukarýdan alýnabilir
        Vector2 characterTargetPoint = new Vector2(character.position.x, character.position.y + characterHeightOffset);
        float distanceToCharacter = Vector2.Distance(eyePosition.position, characterTargetPoint);

        // Eðer karakter algýlama mesafesinin dýþýndaysa takip etme
        if (distanceToCharacter > detectionDistance)
        {
            isChasing = false;
            return;
        }

        // Karakter ile düþman arasýndaki yönü hesapla
        Vector2 directionToCharacter = (characterTargetPoint - (Vector2)eyePosition.position).normalized;

        // Raycast ile düþman ve karakter arasýndaki engelleri kontrol et
        RaycastHit2D hit = Physics2D.Raycast(eyePosition.position, directionToCharacter, distanceToCharacter, obstacleLayer);

        if (hit.collider != null && !hit.collider.CompareTag("Player"))
        {
            // Eðer bir engel varsa, düþman karakteri göremez
            isChasing = false;
            return;
        }

        // Eðer engel yoksa ve karakter menzil içindeyse, takip et
        isChasing = true;
    }

    private void ChaseCharacter()
    {
        if (character == null) return;

        float direction = character.position.x - transform.position.x;

        // Yön deðiþtirme kontrolü
        if (direction < 0 && transform.localScale.x > 0)
        {
            Flip();
        }
        else if (direction > 0 && transform.localScale.x < 0)
        {
            Flip();
        }

        rb.velocity = new Vector2(Mathf.Sign(direction) * chaseSpeed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap") ||
            collision.gameObject.CompareTag("Enemy") ||
            collision.gameObject.CompareTag("rocket") ||
            collision.gameObject.CompareTag("Bullet"))
        {
            EnemyDeath();
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("deadzone"))
        {
            EnemyDeath();
        }
    }

    private void EnemyDeath()
    {
        // Eðer ses sistemi varsa ses oynat
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        if (audioManager != null)
        {
            Vector3 enemyDeathPosition = transform.position;
            audioManager.PlaySoundAtPosition("Enemy_Death", enemyDeathPosition);
        }

        // Ölüm efekti oluþtur
        if (enemyDeathParticle != null)
        {
            Instantiate(enemyDeathParticle, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
