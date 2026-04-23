using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float reflectSpeed;
    public bool isRocketcrash = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();

            AudioManager audioManager = FindObjectOfType<AudioManager>();
            Sound shieldEffect = Array.Find(audioManager.sounds, sound => sound.name == "shieldEffect");
            if (!shieldEffect.source.isPlaying)
            {
                shieldEffect.source.Play();
            }

            if (rb != null)
            {
                rb.velocity = -rb.velocity.normalized * reflectSpeed;
                collision.transform.Rotate(0, 180, 0);
            }
        }

        if (collision.CompareTag("rocket"))
        {
            Destroy(collision.gameObject);
        }
            
    }
    
}
