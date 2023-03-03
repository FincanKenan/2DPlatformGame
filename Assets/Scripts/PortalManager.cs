using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public Transform PortalBir1;
    public Transform PortalBir2;

    public Transform Portal�ki1;
    public Transform Portal�ki2;

    public AudioSource ���nlanma;




    public void OnTriggerEnter2D(Collider2D collision)
    {



        // -------- PORTAL 1 ----------

        if (collision.gameObject.tag == "spawn1-1")
        {
            ���nlanma.Play();
            transform.position = PortalBir2.transform.position;
            StartCoroutine(portal1Kapand�());
        }

        if (collision.gameObject.tag == "spawn1-2")
        {
            ���nlanma.Play();
            transform.position = PortalBir1.transform.position;
            StartCoroutine(portal1Kapand�());
        }
        //-----------PORTAL 2----------

        if (collision.gameObject.tag == "spawn2-1")
        {
            ���nlanma.Play();
            transform.position = Portal�ki2.transform.position;
            StartCoroutine(portal2Kapand�());
        }

        if (collision.gameObject.tag == "spawn2-2")
        {
            ���nlanma.Play();
            transform.position = Portal�ki1.transform.position;
            StartCoroutine(portal2Kapand�());
        }


    }

    public IEnumerator portal1Kapand�()
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
    public IEnumerator portal2Kapand�()
    {
        Portal�ki1.GetComponent<SpriteRenderer>().color = Color.blue;
        Portal�ki1.GetComponent<CapsuleCollider2D>().enabled = false;
        Portal�ki2.GetComponent<CapsuleCollider2D>().enabled = false;
        Portal�ki2.GetComponent<SpriteRenderer>().color = Color.blue;

        yield return new WaitForSeconds(5);

        Portal�ki1.GetComponent<SpriteRenderer>().color = Color.white;
        Portal�ki1.GetComponent<CapsuleCollider2D>().enabled = true;
        Portal�ki2.GetComponent<CapsuleCollider2D>().enabled = true;
        Portal�ki2.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
