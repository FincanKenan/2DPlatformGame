using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    private float mermiH�z� = 20;

    
    void Start()
    {
        rb.velocity = transform.right * mermiH�z�;
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        {
            Destroy(gameObject);
        }
    }
    

}
