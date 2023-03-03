using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    private Animator anim;

    public AudioSource sar�AlarmSes, alarmK�rm�z�;
   

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameObject.Find("Gaz").GetComponent<GazAnim>().sar�Saniye == true)
        {
            if (!sar�AlarmSes.isPlaying)
            {
                sar�AlarmSes.Play();
            }
            
            anim.SetTrigger("alarmSar�");
        }

        if (GameObject.Find("Gaz").GetComponent<GazAnim>().k�rm�z�Saniye == true)
        {
            sar�AlarmSes.Stop();
            if (!alarmK�rm�z�.isPlaying)
            {
                alarmK�rm�z�.Play();
            }
            anim.SetTrigger("alarmK�rm�z�");
        }
    }
}
