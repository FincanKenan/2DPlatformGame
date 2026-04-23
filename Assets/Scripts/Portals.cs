using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour
{
    public Portals linkedPortal;
    public float portalCoolDownTime;
    private bool isPortalActive = true;

    private Animator animator;
    private Animator linkedAnimator;

    private void Start()
    {
        animator = GetComponent<Animator>();

        if (linkedPortal != null)
        {
            linkedAnimator = linkedPortal.GetComponent<Animator>();
        }

       
        if (animator != null)
        {
            animator.SetBool("isActive", true);
        }

        if (linkedAnimator != null)
        {
            linkedAnimator.SetBool("isActive", true);
        }

        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && isPortalActive)
        {
            if(linkedPortal != null && linkedPortal.isPortalActive)
            {
                StartCoroutine(TeleportPlayer(collision.gameObject));

                AudioManager audioManager = FindObjectOfType<AudioManager>();
                Sound portalSound = Array.Find(audioManager.sounds, sound => sound.name == "Portal");
                if (!portalSound.source.isPlaying) // Ses zaten çalmýyorsa
                {
                    portalSound.source.Play();
                }
            }
        }
    }
    private IEnumerator TeleportPlayer(GameObject Player)
    {
        isPortalActive = false;
        linkedPortal.isPortalActive = false;

        Player.transform.position = linkedPortal.transform.position;

        if (animator != null)
        {
            animator.SetBool("isActive", false);
        }

        if (linkedAnimator != null)
        {
            linkedAnimator.SetBool("isActive", false);
        }

        yield return new WaitForSeconds(portalCoolDownTime);

        isPortalActive = true;
        linkedPortal.isPortalActive = true;

        if (animator != null)
        {
            animator.SetBool("isActive", true);
        }

        if (linkedAnimator != null)
        {
            linkedAnimator.SetBool("isActive", true);
        }
    }
}
