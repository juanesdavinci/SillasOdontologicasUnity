using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{

    public Animator Animator;

    public void FadeOut()
    {
        Animator.SetTrigger("Fade");
    }
}
