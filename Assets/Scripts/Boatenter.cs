using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boatenter : MonoBehaviour
{
    public GameObject player;
    public GameObject boat;
    public bool out1;
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "boatenter" && out1 == false)
                {
                    player.SetActive(false);
                    boat.gameObject.GetComponent<NavMeshAgent>().enabled = true;
                    out1 = true;
                }
                else if (hit.transform.gameObject.tag == "boatenter" && out1 == true)
                {
                    player.SetActive(true);
                    boat.gameObject.GetComponent<NavMeshAgent>().enabled = false;
                    out1 = false;
                }
            }
        }
    }
}
