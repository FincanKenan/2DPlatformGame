using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAzKapak : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameObject.Find("Gaz").GetComponent<GazAnim>().s�reBitti == true)
        {
            anim.SetTrigger("GazKap�Ac�k");
        }
    }
}
