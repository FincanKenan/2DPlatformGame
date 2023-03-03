using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject hedefObje;
    private Vector3 hedeflenenObje;
    public Vector3 kameraAyarý;
    private Vector3 boþDeðer = Vector3.zero;
    public float gecikmeZamaný;

    
    public Vector3 sýnýrSað, sýnýrSol, sýnýrÜst, sýnýrAlt;



    void Update()
    {
        


        hedeflenenObje = hedefObje.transform.position + kameraAyarý;

        transform.position = Vector3.SmoothDamp(transform.position, hedeflenenObje, ref boþDeðer, gecikmeZamaný);

      
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, sýnýrSol.x, 100f), Mathf.Clamp(transform.position.y, sýnýrAlt.y, 100f), transform.position.z);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -100f, sýnýrSað.x), Mathf.Clamp(transform.position.y, -100f, sýnýrÜst.y), transform.position.z);
        }
        
    }


    
}
