using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glassesappear : MonoBehaviour
{
    public Animator guy;
    public Animator guy2;
    public GameObject craftgrid;
    public GameObject glasses;
    public GameObject swirl;
    public GameObject obstr;
    void Start()
    {
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            guy.SetTrigger("walk");
            guy2.SetTrigger("walk");
        }
      if(Input.GetKeyDown(KeyCode.C))
        {
            obstr.SetActive(false);
            craftgrid.SetActive(false);
            glasses.SetActive(true);
            swirl.SetActive(true);
        }
    }
}
