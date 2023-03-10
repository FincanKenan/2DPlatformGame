using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHareket : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector3 aNoktası, bNoktası;
    public Transform aNoktasıPozisyon, bNoktasıPozisyon;


    private float hız = 4;

    private bool hareket = true;

    void Start()
    {
        aNoktası = new Vector3(aNoktasıPozisyon.position.x, 0, 0);
        bNoktası = new Vector3(bNoktasıPozisyon.position.x, 0, 0);
    }


    void Update()
    {
        Vector3 mevcutKonum = new Vector3(transform.position.x, 0, 0);


        if (hareket == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, aNoktasıPozisyon.position, hız * Time.deltaTime);
            if (mevcutKonum == aNoktası)
            {
                hareket = false;
            }
        }
        else if (hareket == false)

        {
            transform.position = Vector3.MoveTowards(transform.position, bNoktasıPozisyon.position, hız * Time.deltaTime);
            if (mevcutKonum == bNoktası)
            {
                hareket = true;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.collider.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.collider.transform.SetParent(null);
        }
    }
}
