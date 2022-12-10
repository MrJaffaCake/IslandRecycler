using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backtonormal : MonoBehaviour
{
    public GameObject inventorybag;
    public GameObject glasses;
    public GameObject swirl;
    public GameObject naocariorigin;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            naocariorigin.SetActive(true);
        }
            if (Input.GetKeyDown(KeyCode.N))
        {
            swirl.SetActive(false);
            glasses.SetActive(false);
            inventorybag.SetActive(true);
        }
    }
}
