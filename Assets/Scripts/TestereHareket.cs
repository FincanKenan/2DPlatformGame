using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestereHareket : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector3 aNoktası, bNoktası;
    public Transform aNoktasıPozisyon, bNoktasıPozisyon;


    private float hız = 5;

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
}
