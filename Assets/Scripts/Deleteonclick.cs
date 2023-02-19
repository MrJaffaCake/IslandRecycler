using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deleteonclick : MonoBehaviour
{
    public string tag;
    public GameObject player;
    private bool closeEnough;

    void Update()
    {
        closeEnough = false;
        if (Vector3.Distance(player.transform.position, transform.position) <= 3)
        {
            closeEnough = true;
        }

        if (Input.GetMouseButtonDown(0) && closeEnough)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == tag) Destroy(hit.transform.gameObject);
            }
        }
    }
}
