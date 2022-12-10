using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class clickMove : MonoBehaviour
{

    private NavMeshAgent nav;
    
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out hit, 100))
            {
                if(hit.transform.gameObject.tag == "Terrain")
                nav.destination = hit.point;
            }
        }
    }
}
