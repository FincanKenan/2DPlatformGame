using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public Transform PortalBir1;
    public Transform PortalBir2;

    public Transform PortalÝki1;
    public Transform PortalÝki2;

    public AudioSource ýþýnlanma;




    public void OnTriggerEnter2D(Collider2D collision)
    {



        // -------- PORTAL 1 ----------

        if (collision.gameObject.tag == "spawn1-1")
        {
            ýþýnlanma.Play();
            transform.position = PortalBir2.transform.position;
            StartCoroutine(portal1Kapandý());
        }

        if (collision.gameObject.tag == "spawn1-2")
        {
            ýþýnlanma.Play();
            transform.position = PortalBir1.transform.position;
            StartCoroutine(portal1Kapandý());
        }
        //-----------PORTAL 2----------

        if (collision.gameObject.tag == "spawn2-1")
        {
            ýþýnlanma.Play();
            transform.position = PortalÝki2.transform.position;
            StartCoroutine(portal2Kapandý());
        }

        if (collision.gameObject.tag == "spawn2-2")
        {
            ýþýnlanma.Play();
            transform.position = PortalÝki1.transform.position;
            StartCoroutine(portal2Kapandý());
        }


    }

    public IEnumerator portal1Kapandý()
    {

        PortalBir1.GetComponent<SpriteRenderer>().color = Color.blue;
        PortalBir1.GetComponent<CapsuleCollider2D>().enabled = false;
        PortalBir2.GetComponent<CapsuleCollider2D>().enabled = false;
        PortalBir2.GetComponent<SpriteRenderer>().color = Color.blue;



        yield return new WaitForSeconds(5);

        PortalBir1.GetComponent<SpriteRenderer>().color = Color.red;
        PortalBir1.GetComponent<CapsuleCollider2D>().enabled = true;
        PortalBir2.GetComponent<CapsuleCollider2D>().enabled = true;
        PortalBir2.GetComponent<SpriteRenderer>().color = Color.red;


    }
    public IEnumerator portal2Kapandý()
    {
        PortalÝki1.GetComponent<SpriteRenderer>().color = Color.blue;
        PortalÝki1.GetComponent<CapsuleCollider2D>().enabled = false;
        PortalÝki2.GetComponent<CapsuleCollider2D>().enabled = false;
        PortalÝki2.GetComponent<SpriteRenderer>().color = Color.blue;

        yield return new WaitForSeconds(5);

        PortalÝki1.GetComponent<SpriteRenderer>().color = Color.white;
        PortalÝki1.GetComponent<CapsuleCollider2D>().enabled = true;
        PortalÝki2.GetComponent<CapsuleCollider2D>().enabled = true;
        PortalÝki2.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
