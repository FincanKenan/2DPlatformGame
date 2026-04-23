using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Laser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        Vector3 laserPosition = transform.position;
        FindObjectOfType<AudioManager>().PlaySoundAtPosition("Trap_Laser", laserPosition);
    }
}
