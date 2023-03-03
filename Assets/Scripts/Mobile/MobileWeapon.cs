using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityStandardAssets.CrossPlatformInput;

public class MobileWeapon : MonoBehaviour
{
    public GameObject mermiPrefeb;
    public Transform ateþNoktasý;

    private float ateþetmeHýzý = 1f;
    private float sonrakiAteþ = 0f;

    public float mermiAdedi = 3f;
    private GameObject mermiItem1, mermiItem2, mermiItem3;

    private Animator anim;

    private bool ateþanim;

    public TMP_Text mermiSayýsý;

    public AudioSource mermiCollectSound, ateþEtmeSound;

    void Start()
    {

        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire") && Time.time > sonrakiAteþ && mermiAdedi > 0)
        {
            ateþanim = true;

        }
        else
        {
            ateþanim = false;
        }


        if (ateþanim == true)
        {


            sonrakiAteþ = Time.time + ateþetmeHýzý;
            mermiAdedi -= 1;
            StartCoroutine(Shoot());
        }
        else
        {
            anim.SetBool("Ateþ", false);
        }


        mermiSayýsý.text = mermiAdedi.ToString();


    }


    private void OnTriggerEnter2D(Collider2D collision)  // ---------PLAYERMERMÝ---------
    {
        if (collision.gameObject.tag == "mermiItem1" || collision.gameObject.tag == "mermiItem2" || collision.gameObject.tag == "mermiItem3")
        {
            mermiAdedi += 1;


        }
        if (collision.gameObject.tag == "mermiItem1")
        {
            mermiCollectSound.Play();
            Destroy(GameObject.FindWithTag("mermiItem1"));
        }
        if (collision.gameObject.tag == "mermiItem2")
        {
            mermiCollectSound.Play();
            Destroy(GameObject.FindWithTag("mermiItem2"));
        }
        if (collision.gameObject.tag == "mermiItem3")
        {
            mermiCollectSound.Play();
            Destroy(GameObject.FindWithTag("mermiItem3"));
        }
    }


    private IEnumerator Shoot()
    {
        anim.SetBool("Ateþ", true);
        yield return new WaitForSeconds(0.2f);
        Instantiate(mermiPrefeb, ateþNoktasý.position, ateþNoktasý.rotation);
        ateþEtmeSound.Play();
    }
}
