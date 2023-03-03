using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
    private float h�z = 2;
    private float mesafe = 1;
    private bool sa�ado�ru = true;
    public Transform patrolKontrol;


    private float takipMesafe = 5;
    public Transform player;



    private float rakipTakipH�z� = 5.5f;

    private Animator anim;

    public AudioSource takipAktif;
    public AudioSource y�r�me;

    private void Start()
    {
        anim = GetComponent<Animator>();
        
    }


    void Update()
    {
        
        transform.Translate(h�z * Vector2.right * Time.deltaTime);

        RaycastHit2D platformBilgi = Physics2D.Raycast(patrolKontrol.position, Vector2.down, mesafe);
        if (platformBilgi.collider == false)
        {
            if (sa�ado�ru == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                sa�ado�ru = false;

                
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                sa�ado�ru = true;
                

                
            }
        }



        if (Vector2.Distance(transform.position, player.position) <= takipMesafe )
        {
            if (!takipAktif.isPlaying)
            {
                takipAktif.Play();
            }
            
            h�z = 4;
           
                if (transform.position.x > player.position.x)
                {
                    transform.position = (Vector2.MoveTowards(transform.position, player.position, h�z * Time.deltaTime));
                    transform.eulerAngles = new Vector3(0, -180, 0);
                }
                else if (transform.position.x < player.position.x)
                {
                    transform.position = (Vector2.MoveTowards(transform.position, player.position, h�z * Time.deltaTime));
                    transform.eulerAngles = new Vector3(0, 0, 0);
                
                }
        }
        else
        {
            h�z = 2;
        }
            



        GameObject[] enemies = GameObject.FindGameObjectsWithTag("d��man");

        foreach (GameObject target in enemies)
        {
            if (Vector2.Distance(transform.position,target.transform.position)<=takipMesafe)
            {
                


                if (transform.position.x > target.transform.position.x)
                {
                    transform.position = (Vector2.MoveTowards(transform.position, target.transform.position, rakipTakipH�z�  * Time.deltaTime));
                    transform.eulerAngles = new Vector3(0, -180, 0);
                }
                else if (transform.position.x < target.transform.position.x)
                {
                    transform.position = (Vector2.MoveTowards(transform.position, target.transform.position, rakipTakipH�z�  * Time.deltaTime));
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                
            }
            else
            {
                
            }
            
        }
        if (h�z > 2)
        {
            anim.SetBool("mesafe", true);
        }
        else if(h�z == 2)
        {
            anim.SetBool("mesafe", false);
        }

        

    }

    
}




             




            
            
            
            
            
                
                
            


                
                
