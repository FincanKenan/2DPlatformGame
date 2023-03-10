using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KlavyeHareket : MonoBehaviour
{
    private Rigidbody2D fizik;
    private float yürümeHızı = 8;
    private float yürümeYönü;

    private bool zemindeMi;
    private float zıplamaGücü = 8;
    public LayerMask zemin;
    private float checkRadius = 0.2f;
    public Transform zıplamaKontrol;

    private bool zıplıyorMu;
    private float zamanSayacı;
    private float zıplamaSüresi = 0.35f;

    private int exJump;
    private int exjumpTime = 2;
    private float exZıplamaGücü = 12;

    public AudioSource yürümeSesi;
    public AudioSource zıplamaSesi;
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
        fizik.velocity = new Vector2(yürümeHızı * yürümeYönü, fizik.velocity.y);

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

        zemindeMi = Physics2D.OverlapCircle(zıplamaKontrol.position, checkRadius, zemin);
        if (zemindeMi == true && Input.GetKeyDown(KeyCode.Space))
        {
            fizik.velocity = Vector2.up * zıplamaGücü;

            zıplıyorMu = true;
            zamanSayacı = zıplamaSüresi;
            yürüyor = false;
            if (!zıplamaSesi.isPlaying)
            {
                zıplamaSesi.Play();
            }

        }
        else if (zemindeMi == false && Input.GetKeyDown(KeyCode.Space))
        {
            zıplıyorMu = false;
        }

        if (zıplıyorMu == true && Input.GetKey(KeyCode.Space))
        {
            if (zamanSayacı > 0)
            {
                fizik.velocity = Vector2.up * zıplamaGücü;
                zamanSayacı -= Time.deltaTime;
            }
            else
            {
                zıplıyorMu = false;
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

        if (exJump > 0 && Input.GetKeyDown(KeyCode.Space) && zıplıyorMu == false)
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
            fizik.velocity = Vector2.up * exZıplamaGücü;
            exJump--;
        }





    }



}
