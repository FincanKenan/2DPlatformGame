using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehavior : MonoBehaviour
{
    private Transform character;
    public float rocketSpeed = 5f;
    public float rocketRotation = 200f;
    public float destroyTime = 5f;
    private Rigidbody2D rb;
    public Transform rockotPoint;

    private Shield shield;

    private AudioSource rocketAudioSource;

    public ParticleSystem tarretDeathParticle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError(" HATA: Roket objesinde Rigidbody2D eksik!");
            Destroy(gameObject);
        }

        Destroy(gameObject, destroyTime);

        shield = FindObjectOfType<Shield>();


        rocketAudioSource = gameObject.AddComponent<AudioSource>();

        //  Roket aktif olduðunda sesi çal
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        Sound rocketSound = Array.Find(audioManager.sounds, sound => sound.name == "Rocket_Active");
        if (rocketSound != null)
        {
            rocketAudioSource.clip = rocketSound.clip;
            rocketAudioSource.volume = rocketSound.volume;
            rocketAudioSource.pitch = rocketSound.pitch;
            rocketAudioSource.spatialBlend = 1.0f; // 3D Ses
            rocketAudioSource.loop = true; //  Roket yok olana kadar çal
            rocketAudioSource.Play();
        }

    }

    public void SetTarget(Transform target)
    {
        character = target;
    }

    void FixedUpdate()
    {
        if (character == null) return;
        


        Vector2 direction = (Vector2)character.position - (Vector2)rockotPoint.position;
            direction.Normalize();

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            float smootAngle = Mathf.LerpAngle(rb.rotation, angle, Time.fixedDeltaTime * rocketRotation);
            rb.rotation = smootAngle;

            
            rb.velocity = rockotPoint.up * rocketSpeed;

        

        // float rotateAmount = Vector3.Cross(direction, transform.up).z;
        // rb.angularVelocity = -rotateAmount * rocketRotation;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            RocketDeath();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            RocketDeath();
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            RocketDeath();
        }
        else if (collision.gameObject.CompareTag("rocket"))
        {
            RocketDeath();
        }
        else if (collision.gameObject.CompareTag("trap"))
        {
            RocketDeath();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.gameObject.CompareTag("shield"))
        {
            RocketDeath();
        }
    }

    private void RocketDeath()
    {
        

        AudioManager audioManager = FindObjectOfType<AudioManager>();
        Vector3 rocketPosition = transform.position;
        FindObjectOfType<AudioManager>().PlaySoundAtPosition("Rocket_Destroy", rocketPosition);

        audioManager.StopSound("Rocket_Active");

        TarretDeathEffect();

        Destroy(gameObject);

    }

    private void TarretDeathEffect()
    {
        Instantiate(tarretDeathParticle, transform.position, Quaternion.identity);
    }

}
