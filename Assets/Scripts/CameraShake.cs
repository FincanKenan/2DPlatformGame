using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float sars�nt�H�z� = 0.2f;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void kameraTitreme()
    {
        float xSallanma = Random.Range(-0.35f, 0.35f) * sars�nt�H�z�;
        float ySallanma = Random.Range(-0.35f, 0.35f) * sars�nt�H�z�;

        transform.localPosition = new Vector3(xSallanma, ySallanma, -10);
    }
}
