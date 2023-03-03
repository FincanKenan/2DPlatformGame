using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestereHareket : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector3 aNoktas�, bNoktas�;
    public Transform aNoktas�Pozisyon, bNoktas�Pozisyon;


    private float h�z = 5;

    private bool hareket = true;

    

    void Start()
    {
        aNoktas� = new Vector3(aNoktas�Pozisyon.position.x, 0, 0);
        bNoktas� = new Vector3(bNoktas�Pozisyon.position.x, 0, 0);

        
    }


    void Update()
    {
        Vector3 mevcutKonum = new Vector3(transform.position.x, 0, 0);


        if (hareket == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, aNoktas�Pozisyon.position, h�z * Time.deltaTime);
            if (mevcutKonum == aNoktas�)
            {
                hareket = false;
            }
        }
        else if (hareket == false)

        {
            transform.position = Vector3.MoveTowards(transform.position, bNoktas�Pozisyon.position, h�z * Time.deltaTime);
            if (mevcutKonum == bNoktas�)
            {
                hareket = true;
            }
        }

    }
}
