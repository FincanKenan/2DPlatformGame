using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KapıCollision : MonoBehaviour
{
    private Animator anim;

    public bool kapıAçılmaanim = false;

    public AudioSource kapıKilitliSes;
    public AudioSource kapıaçılmaSes;
    private bool kapıAçıldıBool = false;
    


    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (GameObject.Find("Character").GetComponent<Collision>().kapıAçılma == true)
        {
            anim.SetBool("kapıHazır", true);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameObject.Find("Character").GetComponent<Collision>().kapıAçılma == false || collision.gameObject.tag == "Player")
        {
            kapıKilitliSes.Play();
        }


            if (collision.gameObject.tag == "Player" && GameObject.Find("Character").GetComponent<Collision>().kapıAçılma == true) // player kapı açma alanındaysa ve anahtarlar toplanmışsa komutu.
        {
            kapıAçılmaanim = true;
            
        }
            

            
        {
            if (kapıAçılmaanim == true)
            {
                kapıKilitliSes.Stop();

                if (kapıAçıldıBool == false)
                {
                    kapıaçılmaSes.Play();
                    kapıAçıldıBool = true;
                }
                else
                {
                    kapıaçılmaSes.Stop();
                }
                

                
                
            }
            }

        if (kapıAçılmaanim == true)
        {
            

            anim.SetBool("kapıdurumu", true);

            Debug.Log("açıldı");

            
        }
        


    }
}
