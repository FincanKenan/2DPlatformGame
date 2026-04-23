using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSystem : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject rocketPrefab;  // Roket prefabý
    public Transform firePoint;      // Roketin çýkýþ noktasý
    public float fireRate = 2f;      // Ateþ etme süresi
    public float detectionRange = 10f; // Karakteri algýlama mesafesi

    [Header("Rocket Settings")]
    public float rocketSpeed = 5f;   // Roketin hýzý
    public float rocketRotation = 200f; // Roketin dönüþ hýzý
    public float destroyTime = 5f;   // Roketin yok olma süresi

    public Transform character;  // Takip edilecek karakter
    private bool isCharacterInRange;
    private Coroutine fireRoutine;

    private Animator animator;

    public ParticleSystem rocketDeathParticle;

    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (firePoint == null)
        {
            Debug.LogError("?? HATA: FirePoint atanmadý!");
            firePoint = transform; // Varsayýlan olarak kendi konumunu kullan
        }

        if (rocketPrefab == null)
        {
            Debug.LogError("?? HATA: RocketPrefab atanmadý!");
        }

        StartCoroutine(CheckCharacterDistance());

        animator = GetComponent<Animator>();
    }

    private IEnumerator CheckCharacterDistance()
    {
        while (true)
        {
            if (character != null)
            {
                float distance = Vector2.Distance(transform.position, character.position);
               // Debug.Log("?? Karakter mesafesi: " + distance);

                if (distance < detectionRange)
                {
                    if (!isCharacterInRange)
                    {
                        isCharacterInRange = true;
                        fireRoutine = StartCoroutine(SpawnRockets());
                        animator.SetBool("tarretActive", true);
                    }
                }
                else
                {
                    if (isCharacterInRange)
                    {
                        isCharacterInRange = false;
                        if (fireRoutine != null)
                        {
                            StopCoroutine(fireRoutine);
                            fireRoutine = null;
                            animator.SetBool("tarretActive", false);
                        }
                    }
                }
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    private IEnumerator SpawnRockets()
    {
        
            while (isCharacterInRange)
            {
                yield return new WaitForSeconds(fireRate);

                if (rocketPrefab == null)
                {
                    Debug.LogError("?? HATA: RocketPrefab atanmadý!");
                    yield break;
                }

                if (firePoint == null)
                {
                    Debug.LogError("?? HATA: FirePoint atanmadý!");
                    yield break;
                }

            AudioManager audioManager = FindObjectOfType<AudioManager>();
            Vector3 tarretPosition = transform.position;
            FindObjectOfType<AudioManager>().PlaySoundAtPosition("Tarret_Fire", tarretPosition);

            Debug.Log("?? Roket fýrlatýlýyor...");
                GameObject newRocket = Instantiate(rocketPrefab, firePoint.position, firePoint.rotation);
                newRocket.GetComponent<RocketBehavior>().SetTarget(character);

                
            }    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("rocket"))
        {
            AudioManager audioManager = FindObjectOfType<AudioManager>();
            Vector3 tarretPosition = transform.position;
            FindObjectOfType<AudioManager>().PlaySoundAtPosition("Tarret_Destroy", tarretPosition);

            RocketDeathEffect();

            Destroy(gameObject);
        }
    }

    private void RocketDeathEffect()
    {
        Instantiate(rocketDeathParticle, transform.position, Quaternion.identity);
    }

}
