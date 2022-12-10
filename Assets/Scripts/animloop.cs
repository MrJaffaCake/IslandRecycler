using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animloop : MonoBehaviour
{
    public Animator animator;
    public void loop()
    {
        animator.SetTrigger("Sway");
    }
}
