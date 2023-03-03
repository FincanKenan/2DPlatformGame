using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    private float mermiHýzý = 20;

    
    void Start()
    {
        rb.velocity = transform.right * mermiHýzý;
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
