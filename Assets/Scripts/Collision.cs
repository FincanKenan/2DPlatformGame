using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Collision : MonoBehaviour
{


    
    public bool anahtar1Yok, anahtar2Yok, anahtar3Yok = false;

    public GameObject anahtar1, anahtar2, anahtar3;


    public bool kapıAçılma = false;

    private int anahtarSayısı = 0;
    public int maxAnahtar;
    public TMP_Text AnahtarAdedi;

    public AudioSource anahtarSes;


    void Start()
    {
        if ((anahtar1Yok == false) && (anahtar2Yok == false) && (anahtar3Yok == false))
        {
            maxAnahtar = 3;
        }
        else if ((anahtar1Yok == false) && (anahtar2Yok == false))
        {
            maxAnahtar = 2;
        }
        else if ((anahtar1Yok == false))
        {
            maxAnahtar = 1;
        }

        


    }

    
    void Update()
    {


        AnahtarAdedi.text = anahtarSayısı.ToString() + "/" + maxAnahtar.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "düşman")
        {
            FindObjectOfType<Manager>().EndGame();
        }

        if (collision.gameObject.tag == "Trap")
        {
            FindObjectOfType<Manager>().EndGame();
           
        }

        if (collision.gameObject.tag == "roket")
        {
            FindObjectOfType<Manager>().EndGame();
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            FindObjectOfType<Manager>().EndGame();

        }

        

        
            if (collision.gameObject.tag == "gaz")
            {
                FindObjectOfType<Manager>().EndGame();
            }



       
        
        if (collision.gameObject.tag == "anahtar1")
        {
            anahtarSes.Play();
            anahtar1.GetComponent<SpriteRenderer>().enabled = false;
            anahtar1.GetComponent<Collider2D>().enabled = false;
            anahtar1Yok = true;
            anahtarSayısı += 1;
        }
        if (collision.gameObject.tag == "anahtar2")
        {
            anahtarSes.Play();
            anahtar2.GetComponent<SpriteRenderer>().enabled = false;
            anahtar2.GetComponent<Collider2D>().enabled = false;
            anahtar2Yok = true;
            anahtarSayısı += 1;
        }
        if (collision.gameObject.tag == "anahtar3")
        {
            anahtarSes.Play();
            anahtar3.GetComponent<SpriteRenderer>().enabled = false;
            anahtar3.GetComponent<Collider2D>().enabled = false;
            anahtar3Yok = true;
            anahtarSayısı += 1;
        }

        if (anahtar1Yok == true && anahtar2Yok == true && anahtar3Yok == true)
        {
            kapıAçılma = true;  // Bu koşulu kapıCollision da kapı açılma animasyonu için kullanıyoruz.
        }

        if (GameObject.Find("KapıGiriş").GetComponent<KapıCollision>().kapıAçılmaanim == true && collision.gameObject.tag == "sonrakiseviye")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }



                // ---------- BU KISIM DEMO OYUN İÇİN YAZILDI OYUN BİTİMİNDE ANA EKRANA DÖNMEK İÇİN -------------    

        if (GameObject.Find("KapıGiriş").GetComponent<KapıCollision>().kapıAçılmaanim == true && collision.gameObject.tag == "son")
        {
            SceneManager.LoadScene("SampleScene");
        }

                 // ---------- BU KISIM DEMO OYUN İÇİN YAZILDI OYUN BİTİMİNDE ANA EKRANA DÖNMEK İÇİN -------------    

    }



}






        

        
       
            
            
            
