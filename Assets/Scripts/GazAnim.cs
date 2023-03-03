using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GazAnim : MonoBehaviour
{
    private Animator anim;
    public Text timeRemaining1, timeRemaining2, timeRemaining3, timeRemaining4;


    public float bölüm1Zaman;
    public bool sarýSaniye, kýrmýzýSaniye = false;      // Alarm Animasyonu için..
    
    public bool süreBitti = false;

    public GameObject Effect1;

    public AudioSource geriSayým;
    public AudioSource gazSesi;
    

    private void Start()
    {
        anim = GetComponent<Animator>();

        
        
    }

    

    private void FixedUpdate()
    {
        if (bölüm1Zaman == 0)
        {
            süreBitti = true;
        }

        // ------ Alarm Animasyonu------

        if (bölüm1Zaman <= 20)
        {
            sarýSaniye = true;
        }
        if (bölüm1Zaman <= 0)
        {
            sarýSaniye = false;
            kýrmýzýSaniye = true;
        }

        // ------ Alarm Animasyonu------
        
                                                                        //  ------------ SAMPLE SCENE ---------------
    


       // if (SceneManager.GetActiveScene().name == "SampleScene")
        {
       //         if (bölüm1Zaman > 0)
                {
       //             bölüm1Zaman -= (Time.deltaTime);
                    
                }
       //         else
                {
       //             bölüm1Zaman = 0;
                }
       //  ZamanSayasý(bölüm1Zaman);

       //     if (süreBitti == true)
            {
       //         if (!gazSesi.isPlaying)
                {
       //             gazSesi.Play();
                }
       //         anim.SetBool("açýldý",true);
            }

                                                                            // ----------- BÖLÜM 1 --------------

            if (SceneManager.GetActiveScene().name == "Level1")
            {
                if (bölüm1Zaman > 0)
                {
                    bölüm1Zaman -= (Time.deltaTime);

                }
                else
                {
                    bölüm1Zaman = 0;
                }
                ZamanSayasý(bölüm1Zaman);

                if (süreBitti == true)
                {
                    anim.SetBool("açýldý", true);


                }
            }
        }
                                                                            // ----------- BÖLÜM 2 --------------


        if (SceneManager.GetActiveScene().name == "Level2")
        {
            if (bölüm1Zaman > 0)
            {
                bölüm1Zaman -= (Time.deltaTime);

            }
            else
            {
                bölüm1Zaman = 0;
            }
            ZamanSayasý(bölüm1Zaman);

            if (süreBitti == true)
            {
                anim.SetBool("açýldý", true);
                
                
            }
        }

                                                                                    // ----------- BÖLÜM 3 --------------

        if (SceneManager.GetActiveScene().name == "Level3")
        {
            if (bölüm1Zaman > 0)
            {
                bölüm1Zaman -= (Time.deltaTime);

            }
            else
            {
                bölüm1Zaman = 0;
            }
            ZamanSayasý(bölüm1Zaman);

            if (süreBitti == true)
            {
                anim.SetBool("açýldý", true);


            }
        }
                                                                                // ----------- BÖLÜM 4 --------------

        if (SceneManager.GetActiveScene().name == "Level4")
        {
            if (bölüm1Zaman > 0)
            {
                bölüm1Zaman -= (Time.deltaTime);

            }
            else
            {
                bölüm1Zaman = 0;
            }
            ZamanSayasý(bölüm1Zaman);

            if (süreBitti == true)
            {
                anim.SetBool("açýldý", true);


            }
        }

                                                                                // ----------- BÖLÜM 5 --------------

        if (SceneManager.GetActiveScene().name == "Level5")
        {
            if (bölüm1Zaman > 0)
            {
                bölüm1Zaman -= (Time.deltaTime);

            }
            else
            {
                bölüm1Zaman = 0;
            }
            ZamanSayasý(bölüm1Zaman);

            if (süreBitti == true)
            {
                anim.SetBool("açýldý", true);


            }
        }

                                                                            // ----------- BÖLÜM 6 --------------

        if (SceneManager.GetActiveScene().name == "Level6")
        {
            if (bölüm1Zaman > 0)
            {
                bölüm1Zaman -= (Time.deltaTime);

            }
            else
            {
                bölüm1Zaman = 0;
            }
            ZamanSayasý(bölüm1Zaman);

            if (süreBitti == true)
            {
                anim.SetBool("açýldý", true);


            }
        }

                                                                                    // ----------- BÖLÜM 7 --------------

        if (SceneManager.GetActiveScene().name == "Level7")
        {
            if (bölüm1Zaman > 0)
            {
                bölüm1Zaman -= (Time.deltaTime);

            }
            else
            {
                bölüm1Zaman = 0;
            }
            ZamanSayasý(bölüm1Zaman);

            if (süreBitti == true)
            {
                anim.SetBool("açýldý", true);


            }
        }

                                                                                        // ----------- BÖLÜM 8 --------------

        if (SceneManager.GetActiveScene().name == "Level8")
        {
            if (bölüm1Zaman > 0)
            {
                bölüm1Zaman -= (Time.deltaTime);

            }
            else
            {
                bölüm1Zaman = 0;
            }
            ZamanSayasý(bölüm1Zaman);

            if (süreBitti == true)
            {
                anim.SetBool("açýldý", true);


            }
        }

                                                                            // ----------- BÖLÜM 9 --------------

        if (SceneManager.GetActiveScene().name == "Level9")
        {
            if (bölüm1Zaman > 0)
            {
                bölüm1Zaman -= (Time.deltaTime);

            }
            else
            {
                bölüm1Zaman = 0;
            }
            ZamanSayasý(bölüm1Zaman);

            if (süreBitti == true)
            {
                anim.SetBool("açýldý", true);


            }
        }

                                                                                         // ----------- BÖLÜM 10 --------------

        if (SceneManager.GetActiveScene().name == "Level10")
        {
            if (bölüm1Zaman > 0)
            {
                bölüm1Zaman -= (Time.deltaTime);

            }
            else
            {
                bölüm1Zaman = 0;
            }
            ZamanSayasý(bölüm1Zaman);

            if (süreBitti == true)
            {
                anim.SetBool("açýldý", true);


            }
        }

    }
    public void Update()
    {
        if (süreBitti == true)
        {
            FindObjectOfType<CameraShake>().kameraTitreme();
        }

        if (süreBitti == false)
        {
            Effect1.SetActive(false);
            
        }
        else
        {
            Effect1.SetActive(true);
            
        }

    }

    private void ZamanSayasý (float kalanSüre)
    {
        if (kalanSüre < 0)
        {
            kalanSüre = 0;
        }

        float dakikalar = Mathf.FloorToInt(kalanSüre / 60);
        float saniyeler = Mathf.FloorToInt(kalanSüre % 60);

        timeRemaining1.text = string.Format("{0:00}:{1:00}", dakikalar, saniyeler);
        timeRemaining2.text = string.Format("{0:00}:{1:00}", dakikalar, saniyeler);
        timeRemaining3.text = string.Format("{0:00}:{1:00}", dakikalar, saniyeler);
        timeRemaining4.text = string.Format("{0:00}:{1:00}", dakikalar, saniyeler);


        if (bölüm1Zaman <= 20)
        {
            timeRemaining1.color = Color.yellow;
            timeRemaining2.color = Color.yellow;
            timeRemaining3.color = Color.yellow;
            timeRemaining4.color = Color.yellow;
        }

        if (bölüm1Zaman <= 10)
        {
            if (!geriSayým.isPlaying)
            {
                geriSayým.Play();
                
            }

            timeRemaining1.color = Color.red;
            timeRemaining2.color = Color.red;
            timeRemaining3.color = Color.red;
            timeRemaining4.color = Color.red;
        }

        

        if (bölüm1Zaman == 0)
        {
            
            geriSayým.Stop();
        }

    } 
}
        


     
            
            


            
            
            
            

            

            

            
            



