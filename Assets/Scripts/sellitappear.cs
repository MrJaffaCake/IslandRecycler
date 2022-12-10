using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sellitappear : MonoBehaviour
{
    public GameObject sellit;
    void Start()
    {
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            sellit.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.Z))
        {
            sellit.SetActive(false);
        }
    }
}
