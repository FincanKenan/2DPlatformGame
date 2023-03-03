using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class Manager : MonoBehaviour
{
   // public GameObject GameOverEkraný;
    public GameObject  tuþlarCanvas, göstergeCanvas;
    bool gameOver = false;
    public GameObject Player;
    public GameObject deathEffect;

    public AudioSource deathSound;


    private void Awake()
    {
        Application.targetFrameRate = 144;    
    }

    

    public void EndGame()
    {
        if (gameOver == false)
        {
            StartCoroutine(OyunBitti());

        }
    }




    public IEnumerator OyunBitti()
    {
        Player.GetComponent<Collider2D>().enabled = false;
        Player.GetComponent<SpriteRenderer>().enabled = false;
        FindObjectOfType<MobileWeapon>().enabled = false;
        FindObjectOfType<MobileMovement>().enabled = false;
        FindObjectOfType<CameraFollow>().enabled = false;

        deathSound.Play();
        Instantiate(deathEffect, Player.transform.position, Quaternion.identity);
        
        

        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0f;
     //   GameOverEkraný.SetActive(true);
        tuþlarCanvas.SetActive(false);
        göstergeCanvas.SetActive(false);
        gameOver = true;
        
        //  Player.GetComponent<AudioListener>().enabled = false;
    }


  //  public void Restart()
  //  {
  //      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  //      Time.timeScale = 1f;
  //  }

    

    

    
    void Update()
    {
        if (gameOver == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1f;
        }
    }

}
