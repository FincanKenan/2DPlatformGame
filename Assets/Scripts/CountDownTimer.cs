using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class CountDownTimer : MonoBehaviour
{
    private float countDownTime;
    private float currentTime;

    public List <TextMeshPro> timeTexts = new List<TextMeshPro>();
    private Animator fireEffectAnimator;
    private GameObject fireParentObject;

    private CameraMovement cameraMovement;
    void Start()
    {
        fireParentObject = GameObject.Find("Fire Parent");

        if (fireParentObject != null)
        {
            fireParentObject.SetActive(true);  // Önce aç
            fireEffectAnimator = fireParentObject.GetComponent<Animator>();
            fireParentObject.SetActive(false); // Sonra kapat
        }
        else
        {
            Debug.LogError(" Fire Parent nesnesi bulunamadý!");
        }

        cameraMovement = Camera.main.GetComponent<CameraMovement>();

        switch (SceneManager.GetActiveScene().name)
        {
            case ("SampleScene"):
                countDownTime = 20f;
                break;
            case ("Level1"):
                countDownTime = 40f;
                break;
            case ("Level2"):
                countDownTime = 40f;
                break;
            case ("Level3"):
                countDownTime = 30f;
                break;
            case ("Level4"):
                countDownTime = 60f;
                break;
            case ("Level5"):
                countDownTime = 35f;
                break;
            case ("Level6"):
                countDownTime = 90f;
                break;
            case ("Level7"):
                countDownTime = 65f;
                break;
            case ("Level8"):
                countDownTime = 35f;
                break;
        }
        currentTime = countDownTime;
        TextMeshPro[] allTimetexts = FindObjectsOfType<TextMeshPro>();
        foreach (TextMeshPro text in allTimetexts)
        {
            timeTexts.Add(text);
        }
        UpdateTimeUI();
    }

    
    void Update()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        Sound countDownSound = Array.Find(audioManager.sounds, sound => sound.name == "CountDown_Sound");
        Sound alarmSound = Array.Find(audioManager.sounds, sound => sound.name == "Alarm_Sound");

        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimeUI();

            if (currentTime <= 1)
            {
                currentTime = 0;
                EndTextTime();
                return;
            }
        }

        foreach (TextMeshPro text in timeTexts)
        {
            if (currentTime > 25)
            {
                text.color = Color.green;
            }
            else if (currentTime < 25 && currentTime > 10)
            {
                text.color = Color.yellow;
            }
            else if (currentTime < 11 && currentTime > 0)
            {
                text.color = Color.red;

                if (!countDownSound.source.isPlaying)
                {
                    countDownSound.source.Play();
                }
            }
            else if (currentTime <= 1)
            {
                if (!alarmSound.source.isPlaying)
                {
                    countDownSound.source.Stop();
                    alarmSound.source.Play();
                }
                if (fireParentObject != null && !fireParentObject.activeSelf)
                {
                    fireParentObject.SetActive(true);
                    StartCoroutine(StartFireEffect());
                }
            }
            
        }
        
    }

    IEnumerator StartFireEffect()
    {
        yield return new WaitForSeconds(0.1f); // Küçük bir gecikme

        if (fireEffectAnimator != null)
        {
            Debug.Log(" Animator baðlý: " + fireEffectAnimator.gameObject.name);
            Debug.Log(" Animator parametresi deðiþtirildi!");
            fireEffectAnimator.SetBool("timeOver", true);
            fireEffectAnimator.Play("Fire Parent"); // "FireAnimation" 
        }
        else
        {
            Debug.LogError(" fireEffectAnimator atanmadý! 'Fire Parent' ");
        }
    }

    void UpdateTimeUI()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Tüm saatlere ayný metni yaz
        foreach (TextMeshPro text in timeTexts)
        {
            text.text = timeString;
        }
    }


    void EndTextTime()
    {
        Debug.Log("Time End");

        if(cameraMovement != null)
        {
            cameraMovement.StartShake();
        }
    }
}
