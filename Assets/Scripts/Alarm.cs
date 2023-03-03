using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    private Animator anim;

    public AudioSource sarýAlarmSes, alarmKýrmýzý;
   

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameObject.Find("Gaz").GetComponent<GazAnim>().sarýSaniye == true)
        {
            if (!sarýAlarmSes.isPlaying)
            {
                sarýAlarmSes.Play();
            }
            
            anim.SetTrigger("alarmSarý");
        }

        if (GameObject.Find("Gaz").GetComponent<GazAnim>().kýrmýzýSaniye == true)
        {
            sarýAlarmSes.Stop();
            if (!alarmKýrmýzý.isPlaying)
            {
                alarmKýrmýzý.Play();
            }
            anim.SetTrigger("alarmKýrmýzý");
        }
    }
}
