using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
    private float hýz = 2;
    private float mesafe = 1;
    private bool saðadoðru = true;
    public Transform patrolKontrol;


    private float takipMesafe = 5;
    public Transform player;



    private float rakipTakipHýzý = 5.5f;

    private Animator anim;

    public AudioSource takipAktif;
    public AudioSource yürüme;

    private void Start()
    {
        anim = GetComponent<Animator>();
        
    }


    void Update()
    {
        
        transform.Translate(hýz * Vector2.right * Time.deltaTime);

        RaycastHit2D platformBilgi = Physics2D.Raycast(patrolKontrol.position, Vector2.down, mesafe);
        if (platformBilgi.collider == false)
        {
            if (saðadoðru == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                saðadoðru = false;

                
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                saðadoðru = true;
                

                
            }
        }



        if (Vector2.Distance(transform.position, player.position) <= takipMesafe )
        {
            if (!takipAktif.isPlaying)
            {
                takipAktif.Play();
            }
            
            hýz = 4;
           
                if (transform.position.x > player.position.x)
                {
                    transform.position = (Vector2.MoveTowards(transform.position, player.position, hýz * Time.deltaTime));
                    transform.eulerAngles = new Vector3(0, -180, 0);
                }
                else if (transform.position.x < player.position.x)
                {
                    transform.position = (Vector2.MoveTowards(transform.position, player.position, hýz * Time.deltaTime));
                    transform.eulerAngles = new Vector3(0, 0, 0);
                
                }
        }
        else
        {
            hýz = 2;
        }
            



        GameObject[] enemies = GameObject.FindGameObjectsWithTag("düþman");

        foreach (GameObject target in enemies)
        {
            if (Vector2.Distance(transform.position,target.transform.position)<=takipMesafe)
            {
                


                if (transform.position.x > target.transform.position.x)
                {
                    transform.position = (Vector2.MoveTowards(transform.position, target.transform.position, rakipTakipHýzý  * Time.deltaTime));
                    transform.eulerAngles = new Vector3(0, -180, 0);
                }
                else if (transform.position.x < target.transform.position.x)
                {
                    transform.position = (Vector2.MoveTowards(transform.position, target.transform.position, rakipTakipHýzý  * Time.deltaTime));
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                
            }
            else
            {
                
            }
            
        }
        if (hýz > 2)
        {
            anim.SetBool("mesafe", true);
        }
        else if(hýz == 2)
        {
            anim.SetBool("mesafe", false);
        }

        

    }

    
}




             




            
            
            
            
            
                
                
            


                
                
