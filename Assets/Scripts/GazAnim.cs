using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GazAnim : MonoBehaviour
{
    private Animator anim;
    public Text timeRemaining1, timeRemaining2, timeRemaining3, timeRemaining4;


    public float b�l�m1Zaman;
    public bool sar�Saniye, k�rm�z�Saniye = false;      // Alarm Animasyonu i�in..
    
    public bool s�reBitti = false;

    public GameObject Effect1;

    public AudioSource geriSay�m;
    public AudioSource gazSesi;
    

    private void Start()
    {
        anim = GetComponent<Animator>();

        
        
    }

    

    private void FixedUpdate()
    {
        if (b�l�m1Zaman == 0)
        {
            s�reBitti = true;
        }

        // ------ Alarm Animasyonu------

        if (b�l�m1Zaman <= 20)
        {
            sar�Saniye = true;
        }
        if (b�l�m1Zaman <= 0)
        {
            sar�Saniye = false;
            k�rm�z�Saniye = true;
        }

        // ------ Alarm Animasyonu------
        
                                                                        //  ------------ SAMPLE SCENE ---------------
    


       // if (SceneManager.GetActiveScene().name == "SampleScene")
        {
       //         if (b�l�m1Zaman > 0)
                {
       //             b�l�m1Zaman -= (Time.deltaTime);
                    
                }
       //         else
                {
       //             b�l�m1Zaman = 0;
                }
       //  ZamanSayas�(b�l�m1Zaman);

       //     if (s�reBitti == true)
            {
       //         if (!gazSesi.isPlaying)
                {
       //             gazSesi.Play();
                }
       //         anim.SetBool("a��ld�",true);
            }

                                                                            // ----------- B�L�M 1 --------------

            if (SceneManager.GetActiveScene().name == "Level1")
            {
                if (b�l�m1Zaman > 0)
                {
                    b�l�m1Zaman -= (Time.deltaTime);

                }
                else
                {
                    b�l�m1Zaman = 0;
                }
                ZamanSayas�(b�l�m1Zaman);

                if (s�reBitti == true)
                {
                    anim.SetBool("a��ld�", true);


                }
            }
        }
                                                                            // ----------- B�L�M 2 --------------


        if (SceneManager.GetActiveScene().name == "Level2")
        {
            if (b�l�m1Zaman > 0)
            {
                b�l�m1Zaman -= (Time.deltaTime);

            }
            else
            {
                b�l�m1Zaman = 0;
            }
            ZamanSayas�(b�l�m1Zaman);

            if (s�reBitti == true)
            {
                anim.SetBool("a��ld�", true);
                
                
            }
        }

                                                                                    // ----------- B�L�M 3 --------------

        if (SceneManager.GetActiveScene().name == "Level3")
        {
            if (b�l�m1Zaman > 0)
            {
                b�l�m1Zaman -= (Time.deltaTime);

            }
            else
            {
                b�l�m1Zaman = 0;
            }
            ZamanSayas�(b�l�m1Zaman);

            if (s�reBitti == true)
            {
                anim.SetBool("a��ld�", true);


            }
        }
                                                                                // ----------- B�L�M 4 --------------

        if (SceneManager.GetActiveScene().name == "Level4")
        {
            if (b�l�m1Zaman > 0)
            {
                b�l�m1Zaman -= (Time.deltaTime);

            }
            else
            {
                b�l�m1Zaman = 0;
            }
            ZamanSayas�(b�l�m1Zaman);

            if (s�reBitti == true)
            {
                anim.SetBool("a��ld�", true);


            }
        }

                                                                                // ----------- B�L�M 5 --------------

        if (SceneManager.GetActiveScene().name == "Level5")
        {
            if (b�l�m1Zaman > 0)
            {
                b�l�m1Zaman -= (Time.deltaTime);

            }
            else
            {
                b�l�m1Zaman = 0;
            }
            ZamanSayas�(b�l�m1Zaman);

            if (s�reBitti == true)
            {
                anim.SetBool("a��ld�", true);


            }
        }

                                                                            // ----------- B�L�M 6 --------------

        if (SceneManager.GetActiveScene().name == "Level6")
        {
            if (b�l�m1Zaman > 0)
            {
                b�l�m1Zaman -= (Time.deltaTime);

            }
            else
            {
                b�l�m1Zaman = 0;
            }
            ZamanSayas�(b�l�m1Zaman);

            if (s�reBitti == true)
            {
                anim.SetBool("a��ld�", true);


            }
        }

                                                                                    // ----------- B�L�M 7 --------------

        if (SceneManager.GetActiveScene().name == "Level7")
        {
            if (b�l�m1Zaman > 0)
            {
                b�l�m1Zaman -= (Time.deltaTime);

            }
            else
            {
                b�l�m1Zaman = 0;
            }
            ZamanSayas�(b�l�m1Zaman);

            if (s�reBitti == true)
            {
                anim.SetBool("a��ld�", true);


            }
        }

                                                                                        // ----------- B�L�M 8 --------------

        if (SceneManager.GetActiveScene().name == "Level8")
        {
            if (b�l�m1Zaman > 0)
            {
                b�l�m1Zaman -= (Time.deltaTime);

            }
            else
            {
                b�l�m1Zaman = 0;
            }
            ZamanSayas�(b�l�m1Zaman);

            if (s�reBitti == true)
            {
                anim.SetBool("a��ld�", true);


            }
        }

                                                                            // ----------- B�L�M 9 --------------

        if (SceneManager.GetActiveScene().name == "Level9")
        {
            if (b�l�m1Zaman > 0)
            {
                b�l�m1Zaman -= (Time.deltaTime);

            }
            else
            {
                b�l�m1Zaman = 0;
            }
            ZamanSayas�(b�l�m1Zaman);

            if (s�reBitti == true)
            {
                anim.SetBool("a��ld�", true);


            }
        }

                                                                                         // ----------- B�L�M 10 --------------

        if (SceneManager.GetActiveScene().name == "Level10")
        {
            if (b�l�m1Zaman > 0)
            {
                b�l�m1Zaman -= (Time.deltaTime);

            }
            else
            {
                b�l�m1Zaman = 0;
            }
            ZamanSayas�(b�l�m1Zaman);

            if (s�reBitti == true)
            {
                anim.SetBool("a��ld�", true);


            }
        }

    }
    public void Update()
    {
        if (s�reBitti == true)
        {
            FindObjectOfType<CameraShake>().kameraTitreme();
        }

        if (s�reBitti == false)
        {
            Effect1.SetActive(false);
            
        }
        else
        {
            Effect1.SetActive(true);
            
        }

    }

    private void ZamanSayas� (float kalanS�re)
    {
        if (kalanS�re < 0)
        {
            kalanS�re = 0;
        }

        float dakikalar = Mathf.FloorToInt(kalanS�re / 60);
        float saniyeler = Mathf.FloorToInt(kalanS�re % 60);

        timeRemaining1.text = string.Format("{0:00}:{1:00}", dakikalar, saniyeler);
        timeRemaining2.text = string.Format("{0:00}:{1:00}", dakikalar, saniyeler);
        timeRemaining3.text = string.Format("{0:00}:{1:00}", dakikalar, saniyeler);
        timeRemaining4.text = string.Format("{0:00}:{1:00}", dakikalar, saniyeler);


        if (b�l�m1Zaman <= 20)
        {
            timeRemaining1.color = Color.yellow;
            timeRemaining2.color = Color.yellow;
            timeRemaining3.color = Color.yellow;
            timeRemaining4.color = Color.yellow;
        }

        if (b�l�m1Zaman <= 10)
        {
            if (!geriSay�m.isPlaying)
            {
                geriSay�m.Play();
                
            }

            timeRemaining1.color = Color.red;
            timeRemaining2.color = Color.red;
            timeRemaining3.color = Color.red;
            timeRemaining4.color = Color.red;
        }

        

        if (b�l�m1Zaman == 0)
        {
            
            geriSay�m.Stop();
        }

    } 
}
        


     
            
            


            
            
            
            

            

            

            
            



