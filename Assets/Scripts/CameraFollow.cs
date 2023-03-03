using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject hedefObje;
    private Vector3 hedeflenenObje;
    public Vector3 kameraAyar�;
    private Vector3 bo�De�er = Vector3.zero;
    public float gecikmeZaman�;

    
    public Vector3 s�n�rSa�, s�n�rSol, s�n�r�st, s�n�rAlt;



    void Update()
    {
        


        hedeflenenObje = hedefObje.transform.position + kameraAyar�;

        transform.position = Vector3.SmoothDamp(transform.position, hedeflenenObje, ref bo�De�er, gecikmeZaman�);

      
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, s�n�rSol.x, 100f), Mathf.Clamp(transform.position.y, s�n�rAlt.y, 100f), transform.position.z);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -100f, s�n�rSa�.x), Mathf.Clamp(transform.position.y, -100f, s�n�r�st.y), transform.position.z);
        }
        
    }


    
}
