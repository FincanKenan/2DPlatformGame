using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterInteraction : MonoBehaviour
{
    public GameObject[] keys;
    private int keyCollected = 0;

    public GameObject[] powercells;
    private int powerCollected = 0;
    public int cells;
    public GameObject bulletPrefeb;
    public Transform firePoint;
    public float bulletSpeed;
    private float nextfireTime;
    private float fireRate = 0.5f;

    public UIManager uýmanager;
    public KeyTracker keyTracker;

    [Header("Shield")]
    public GameObject shieldObject;
    public Collider2D shieldCollider;
    public float shiledTime;
    private bool isShieldActive = false;

    private Vector3 lastPlatformPosition; // Hareket Platform
    

    public ParticleSystem characterDeathParticle;

    


    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
       
        
        cells = powerCollected;

        if(shieldObject != null)
        {
            shieldObject.SetActive(false);
            shieldCollider.enabled = false;
        }
    }

    
    void Update()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();

        cells = powerCollected;
        if(Input.GetKeyDown(KeyCode.LeftControl) && cells > 0 && Time.time>=nextfireTime)
        {
            Shoot();

            nextfireTime = Time.time+fireRate;

            Sound shootSound = Array.Find(audioManager.sounds, sound => sound.name == "Shoot_Player");
            if (!shootSound.source.isPlaying)
            {
                shootSound.source.Play();
            }

            anim.SetBool("isShooting", true);

            StartCoroutine(ShootAnim());
        }

        if(Input.GetKeyDown(KeyCode.E)&& cells > 0 && !isShieldActive)
        {
            ActiveSheild();

            anim.SetBool("isShieldAnim", true);

            StartCoroutine(ShieldAnim());

            Sound shieldSound = Array.Find(audioManager.sounds, sound => sound.name == "ShiledActive");
            if (!shieldSound.source.isPlaying)
            {
                shieldSound.source.Play();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

       
           
        


        Debug.Log("Temas edilen obje: " + other.gameObject.name);  

        // -----KEY------

        foreach (GameObject key in keys)
        {
            if(other.gameObject == key)
            {
                keyCollected++;
                key.SetActive(false);
                Debug.Log("Anahtar Alýndý. Mevcut Anahtar Sayýsý: " +  keyCollected);

                AudioManager audioManager = FindObjectOfType<AudioManager>();
                Sound keySound = Array.Find(audioManager.sounds, sound => sound.name == "KeyCollect");
                if (!keySound.source.isPlaying)
                {
                    keySound.source.Play();
                }

                uýmanager.addKey();
            }
        }

        // -----KEY------

        

        // -----POWERCELL------

      //  foreach (GameObject power in powercells)
        {
            if (other.CompareTag("powercell"))
            {
                powerCollected++;
                Destroy(other.gameObject);
                Debug.Log("Güç topu alýndý. Güç Topu Sayýsý: "+ powerCollected);

                AudioManager audioManager = FindObjectOfType<AudioManager>();
                Sound powerballSound = Array.Find(audioManager.sounds, sound => sound.name == "Powerball_Collect");
                if (!powerballSound.source.isPlaying)
                {
                    powerballSound.source.Play();
                }

                uýmanager.addCell();
            }
        }


        // -----POWERCELL------

        if (other.CompareTag("deadzone"))
        {
            CharacterDeath();
        }
    }

    public bool allKeyscollected()
    {
        return keyCollected == keys.Length;
    }

    public bool allCellscollected()
    {
        return powerCollected == powercells.Length;
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefeb,firePoint.position , firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        float direction = transform.localScale.x;
        rb.velocity = new Vector2(direction * bulletSpeed, 0);

        if(direction > 0)
        {
            bullet.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            bullet.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        powerCollected--;

        uýmanager.removeCell();
    }

    private void ActiveSheild()
    {
        if(shieldObject != null && !isShieldActive)
        {
            shieldObject.SetActive(true);
            shieldCollider.enabled = true;
            isShieldActive = true;
            powerCollected--;
            uýmanager.removeCell();

            StartCoroutine(DeactiveSheieldAfterTime());

        }
    }

    private IEnumerator DeactiveSheieldAfterTime()
    {
        yield return new WaitForSeconds(shiledTime);
        shieldObject.SetActive(false);
        shieldCollider.enabled = false;
        isShieldActive = false;

    }

    private IEnumerator ShieldAnim()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("isShieldAnim", false);
    }

    private IEnumerator ShootAnim()
    {
        yield return new WaitForSeconds(0.30f);
        anim.SetBool("isShooting", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            CharacterDeath();
            Debug.Log("Karakter yok oldu.");
        }

        if (collision.gameObject.CompareTag("trap"))
        {
            CharacterDeath();
        }

        if (collision.gameObject.CompareTag("rocket"))
        {
            CharacterDeath();
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            CharacterDeath();
        }

        // Hareket Platform

        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            lastPlatformPosition = collision.transform.position;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            Vector3 platformVelocity = collision.transform.position - lastPlatformPosition;
            transform.position += platformVelocity; // Platformun hareketine ekle
            lastPlatformPosition = collision.transform.position;
        }
    }

        private void CharacterDeath()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        Sound characterDeathSound = Array.Find(audioManager.sounds, sound => sound.name == "Character_Death");
        if (!characterDeathSound.source.isPlaying)
        {
            characterDeathSound.source.Play();
        }

        CharacterDeathEffect();
        Destroy(gameObject);
        FindObjectOfType<Manager>().RestartStart();
    }

    private void CharacterDeathEffect()
    {
       Instantiate(characterDeathParticle,transform.position, Quaternion.identity);
    }
}
