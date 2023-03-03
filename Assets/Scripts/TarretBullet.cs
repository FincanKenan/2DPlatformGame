using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(Rigidbody2D))]
public class TarretBullet : MonoBehaviour
{
    private float mermiHýzý = 10;
    private Rigidbody2D rb;

    private float dönüþHýzý = 400;

    public GameObject rocketEffect;

    public AudioSource patlamaEfekti;
    public AudioSource roketTakip;
    private bool patlamaSesi;

    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        
    }

    void FixedUpdate()
    {
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject hedef in player)
        {
            Vector2 gidiþYönü = (Vector2)hedef.transform.position - rb.position;

            gidiþYönü.Normalize();

            float dönüþDeðeri = Vector3.Cross(gidiþYönü, transform.up).z;

            rb.angularVelocity = -dönüþDeðeri * dönüþHýzý;

            rb.velocity = transform.up * mermiHýzý;
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        
            patlamaSesi = true;
            StartCoroutine(Patlama());
        
        
    }

    public IEnumerator Patlama()
    {

        if (patlamaSesi == true)
        {
            roketTakip.Stop();
            patlamaEfekti.Play();
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            var effect = Instantiate(rocketEffect, transform.position, Quaternion.identity);

            yield return new WaitForSeconds(0.7f);
            Destroy(effect);
            Destroy(gameObject);
            
        }


    }
}

        

        
    
        

            

        

        
