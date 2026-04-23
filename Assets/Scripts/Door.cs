using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private KeyTracker keytracker;
    private Animator anim;
    public GameObject doorBack;

    private bool isdoorOpeningsound = false;
    public bool isdoorReady = false;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        keytracker = FindObjectOfType<KeyTracker>();
    }

   
    void Update()
    {
        if(keytracker.iskeyActive == true)
        {
            anim.SetBool("isYellow", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(keytracker.iskeyActive == true && collision.CompareTag("Player"))
        {
            AudioManager audioManager = FindObjectOfType<AudioManager>();
            Sound doorOpenSound = Array.Find(audioManager.sounds, sound => sound.name == "Door_Openning");
            if (!doorOpenSound.source.isPlaying && isdoorOpeningsound == false)
            {
                doorOpenSound.source.Play();
                isdoorOpeningsound =true;
            }

            anim.SetBool("isGreen", true);
            anim.SetBool("isYellow", false);

            isdoorReady = true;
        }
    }
}
