using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityStandardAssets.CrossPlatformInput;

public class MobileWeapon : MonoBehaviour
{
    public GameObject mermiPrefeb;
    public Transform ate�Noktas�;

    private float ate�etmeH�z� = 1f;
    private float sonrakiAte� = 0f;

    public float mermiAdedi = 3f;
    private GameObject mermiItem1, mermiItem2, mermiItem3;

    private Animator anim;

    private bool ate�anim;

    public TMP_Text mermiSay�s�;

    public AudioSource mermiCollectSound, ate�EtmeSound;

    void Start()
    {

        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire") && Time.time > sonrakiAte� && mermiAdedi > 0)
        {
            ate�anim = true;

        }
        else
        {
            ate�anim = false;
        }


        if (ate�anim == true)
        {


            sonrakiAte� = Time.time + ate�etmeH�z�;
            mermiAdedi -= 1;
            StartCoroutine(Shoot());
        }
        else
        {
            anim.SetBool("Ate�", false);
        }


        mermiSay�s�.text = mermiAdedi.ToString();


    }


    private void OnTriggerEnter2D(Collider2D collision)  // ---------PLAYERMERM�---------
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
        anim.SetBool("Ate�", true);
        yield return new WaitForSeconds(0.2f);
        Instantiate(mermiPrefeb, ate�Noktas�.position, ate�Noktas�.rotation);
        ate�EtmeSound.Play();
    }
}
