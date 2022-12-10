using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryslide : MonoBehaviour
{
    public Animator animator;
    int open = 2;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void slide()
    {
        if (open % 2 == 0)
        {
            animator.SetTrigger("slidein");
            open++;
        }
        else
        {
            animator.SetTrigger("slideout");
            open++;
        }
    }
}
