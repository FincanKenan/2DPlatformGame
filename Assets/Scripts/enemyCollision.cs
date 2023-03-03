using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCollision : MonoBehaviour
{
    public GameObject enemyDeathEffect;

    public AudioSource enemydeathSound;

    void EnemyDeath()
    {
        StartCoroutine(düþmanÖlüm());
    }
    IEnumerator düþmanÖlüm()
    {
        enemydeathSound.Play();
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Instantiate(enemyDeathEffect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1.2f);
        Destroy(gameObject);
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "düþman")
        {
            EnemyDeath();
        }
        

        if (collision.gameObject.tag == "Trap")
        {
            EnemyDeath();
        }

        if (collision.gameObject.tag == "roket")
        {
            EnemyDeath();
        }

        if (collision.gameObject.tag == "PlayerMermi")
        {
            EnemyDeath();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "gaz")
        {
            EnemyDeath();
        }
        
    }

    void Update()
    {
        
        

        
    }
}
        
        
