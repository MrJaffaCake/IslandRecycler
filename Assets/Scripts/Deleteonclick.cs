using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deleteonclick : MonoBehaviour
{
    public string tag;
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
                if (hit.transform.gameObject.tag == tag)
                Destroy(hit.transform.gameObject);
            }
        }
    }
}
