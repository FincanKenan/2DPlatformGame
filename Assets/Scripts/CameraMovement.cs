using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform character;
    public float smoothTime;
    public Vector3 offsett;
    private Vector3 velocity = Vector3.zero;

    private bool isShaking = false;
    public float shakeMagnitude;
    
   

    
    void LateUpdate()
    {
        if(character == null)
        
            return;
        
        
            Vector3 desiredPosition = character.position + offsett;

            

        if (isShaking)
        {
            transform.position = desiredPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
        }
        
    }

    public void StartShake()
    {
        isShaking = true;
    }
    public void StopShaking()
    {
        isShaking = false;
    }
}
