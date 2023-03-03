using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tarret : MonoBehaviour
{
    public Transform ateþNoktasý;
    public GameObject roketPrefeb;
    private float Range;
    public Transform Player;

    
    

    private Animator anim;

    




    void Start()
    {
        InvokeRepeating("Ateþ", 0f, 5f);
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

    

    void TaretAteþ()
    {
        float mesafe = Vector3.Distance(transform.position, Player.position);

        if (mesafe <= Range)
        {
            
            Ateþ();
        }
        
        
        
    }

    private void Ateþ()
    {
       
        Instantiate(roketPrefeb, ateþNoktasý.position, ateþNoktasý.rotation);
        
    }

}
    
                

            
            

            
            
            
