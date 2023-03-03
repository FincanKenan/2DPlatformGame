using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHareket : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector3 aNoktasý, bNoktasý;
    public Transform aNoktasýPozisyon, bNoktasýPozisyon;


    private float hýz = 4;

    private bool hareket = true;

    void Start()
    {
        aNoktasý = new Vector3(aNoktasýPozisyon.position.x, 0, 0);
        bNoktasý = new Vector3(bNoktasýPozisyon.position.x, 0, 0);
    }


    void Update()
    {
        Vector3 mevcutKonum = new Vector3(transform.position.x, 0, 0);


        if (hareket == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, aNoktasýPozisyon.position, hýz * Time.deltaTime);
            if (mevcutKonum == aNoktasý)
            {
                hareket = false;
            }
        }
        else if (hareket == false)

        {
            transform.position = Vector3.MoveTowards(transform.position, bNoktasýPozisyon.position, hýz * Time.deltaTime);
            if (mevcutKonum == bNoktasý)
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
