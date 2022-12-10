using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtlecome : MonoBehaviour
{
    public Animator turtle;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            turtle.SetTrigger("slidein");
        }
    }
}
