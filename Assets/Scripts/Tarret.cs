using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tarret : MonoBehaviour
{
    public Transform ate�Noktas�;
    public GameObject roketPrefeb;
    private float Range;
    public Transform Player;

    
    

    private Animator anim;

    




    void Start()
    {
        InvokeRepeating("Ate�", 0f, 5f);
        anim = GetComponent<Animator>();
        
    }

    
    void Update()
    {
        

        
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
        
    }

    

    void TaretAte�()
    {
        float mesafe = Vector3.Distance(transform.position, Player.position);

        if (mesafe <= Range)
        {
            
            Ate�();
        }
        
        
        
    }

    private void Ate�()
    {
       
        Instantiate(roketPrefeb, ate�Noktas�.position, ate�Noktas�.rotation);
        
    }

}
    
                

            
            

            
            
            
