using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callcrafting : MonoBehaviour
{
    public GameObject craftinggrid;
    public GameObject inventorybag;
    public GameObject obstructor;
    void Start()
    {

    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            obstructor.SetActive(true);
            inventorybag.SetActive(false);
            craftinggrid.SetActive(true);
        }
    }
}

