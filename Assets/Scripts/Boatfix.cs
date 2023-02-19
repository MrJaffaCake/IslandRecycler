using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boatfix : MonoBehaviour
{
    public GameObject smoke;
    public GameObject boatfixed;
    public GameObject boatbroken;
    public GameObject player;

    private bool closeEnough;

    void Update()
    {
        closeEnough = false;
        if (Vector3.Distance(player.transform.position, transform.position) <= 6)
        {
            closeEnough = true;
        }

        if (Input.GetMouseButtonDown(0) && closeEnough)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "boatfix")
                {
                    smoke.SetActive(true);
                    Invoke("boatappear", 3);
                }
            }
        } 
    }
    void boatappear()
    {
        smoke.SetActive(false);
        boatfixed.SetActive(true);
        boatbroken.SetActive(false);
    }
}
