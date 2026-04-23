using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Saw : MonoBehaviour
{
    
    void Start()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        Vector3 sawPosition = transform.position;
        FindObjectOfType<AudioManager>().PlaySoundAtPosition("Trap_Saw", sawPosition);
    }

    
    
}
