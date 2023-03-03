using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KlavyeHareket : MonoBehaviour
{
    private Rigidbody2D fizik;
    private float yürümeHýzý = 8;
    private float yürümeYönü;

    private bool zemindeMi;
    private float zýplamaGücü = 8;
    public LayerMask zemin;
    private float checkRadius = 0.2f;
    public Transform zýplamaKontrol;

    private bool zýplýyorMu;
    private float zamanSayacý;
    private float zýplamaSüresi = 0.35f;

    private int exJump;
    private int exjumpTime = 2;
    private float exZýplamaGücü = 12;

    public AudioSource yürümeSesi;
    public AudioSource zýplamaSesi;
    public AudioSource exJumpSound;
    private bool yürüyor = false;



    private Animator animator;
    void Start()
    {
        fizik = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        yürümeYönü = Input.GetAxisRaw("Horizontal");
        fizik.velocity = new Vector2(yürümeHýzý * yürümeYönü, fizik.velocity.y);

        if (yürümeYönü < 0)
        {


            transform.eulerAngles = new Vector3(0, -180, 0);
        }
        else if (yürümeYönü > 0)
        {


            transform.eulerAngles = new Vector3(0, 0, 0);
        }




        if (yürümeYönü == 0)
        {
            yürüyor = false;
            animator.SetBool("Running", false);
        }
        else
        {
            animator.SetBool("Running", true);
        }


    }
    void Update()
    {

        zemindeMi = Physics2D.OverlapCircle(zýplamaKontrol.position, checkRadius, zemin);
        if (zemindeMi == true && Input.GetKeyDown(KeyCode.Space))
        {
            fizik.velocity = Vector2.up * zýplamaGücü;

            zýplýyorMu = true;
            zamanSayacý = zýplamaSüresi;
            yürüyor = false;
            if (!zýplamaSesi.isPlaying)
            {
                zýplamaSesi.Play();
            }

        }
        else if (zemindeMi == false && Input.GetKeyDown(KeyCode.Space))
        {
            zýplýyorMu = false;
        }

        if (zýplýyorMu == true && Input.GetKey(KeyCode.Space))
        {
            if (zamanSayacý > 0)
            {
                fizik.velocity = Vector2.up * zýplamaGücü;
                zamanSayacý -= Time.deltaTime;
            }
            else
            {
                zýplýyorMu = false;
            }

        }

        if (zemindeMi == true && yürümeYönü != 0)
        {
            yürüyor = true;
        }
        else if (zemindeMi == false && yürümeYönü != 0)
        {
            yürüyor = false;
        }

        if (yürüyor == true)
        {
            if (!yürümeSesi.isPlaying)
            {
                yürümeSesi.Play();
            }
        }
        else
        {
            yürümeSesi.Stop();
        }



        if (zemindeMi == false)
        {
            animator.SetBool("Jumping", true);
        }
        else
        {
            animator.SetBool("Jumping", false);
        }


        if (zemindeMi == true)
        {
            exJump = exjumpTime;
        }

        if (exJump > 0 && Input.GetKeyDown(KeyCode.Space) && zýplýyorMu == false)
        {
            if (!exJumpSound.isPlaying)
            {
                exJumpSound.Play();
            }
            animator.SetBool("ExJump", true);
        }
        else if (zemindeMi == true)
        {
            animator.SetBool("ExJump", false);
        }


        if (Input.GetKeyDown(KeyCode.Space) && exJump > 0)
        {
            fizik.velocity = Vector2.up * exZýplamaGücü;
            exJump--;
        }





    }



}
