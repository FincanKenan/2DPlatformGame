using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTracker : MonoBehaviour
{
    public Transform indicator;
    public GameObject[] keys;
    public GameObject door;

    public float indicatorRadius;

    private GameObject targetKey;
    public bool iskeyActive = false;

    private bool isdoorReadySound = false;

   
    public void Update()
    {
        if (!iskeyActive)
        {
            FindClosestKey();
        }
        else 
        {
            targetKey = door.gameObject;
            AudioManager audioManager = FindObjectOfType<AudioManager>();
            Sound doorReadySound = Array.Find(audioManager.sounds, sound => sound.name == "DoorReady");
            if (!doorReadySound.source.isPlaying && isdoorReadySound == false)
            {
                doorReadySound.source.Play();
                isdoorReadySound = true;
            }
            
        }
        if(targetKey != null)
        {
            RotateIndicator(targetKey.transform);
        }

        
    }

    private void FindClosestKey()
    {
        float shortestDistance = Mathf.Infinity;
        GameObject closesetKey = null;

        foreach(GameObject key in keys)
        {
            if (key.activeSelf)
            {
                float distance = Vector3.Distance(transform.position,key.transform.position);
                if(distance < shortestDistance)
                {
                    shortestDistance = distance;
                    closesetKey = key;
                }
            }
        }

        targetKey = closesetKey;
        if(targetKey == null)
        {
            iskeyActive = true;
        }
    }

    private void RotateIndicator(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Vector3 newIndicatorPosition = transform.position + (direction * indicatorRadius);
        indicator.position = newIndicatorPosition;

        float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        indicator.rotation = Quaternion.Euler(0,0,Angle-90);
    }
}
