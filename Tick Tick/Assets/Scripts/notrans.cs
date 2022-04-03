using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notrans : MonoBehaviour
{
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();

        anim.SetTrigger("noFade");
    }

}
