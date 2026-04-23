using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float lifeTime = 5f;

    private void Start()
    {
            Destroy(gameObject,lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("trap"))
        {
            Destroy(gameObject);
            AudioManager audioManager = FindObjectOfType<AudioManager>();
            Vector3 bulletPosition = transform.position;
            FindObjectOfType<AudioManager>().PlaySoundAtPosition("Bullet_Hit", bulletPosition);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
          //  Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("trap"))
        {
            Destroy (gameObject);
        }
        if (collision.gameObject.CompareTag("rocket"))
        {
            Destroy(gameObject);
            Destroy (collision.gameObject);
        }
    }


}
