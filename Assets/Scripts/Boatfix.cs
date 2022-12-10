using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boatfix : MonoBehaviour
{
    public GameObject trashspawns;
    public GameObject smoke;
    public GameObject boatfixed;
    public GameObject boatbroken;
    public GameObject player;
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
        trashspawns.SetActive(true);
        this.GetComponent<CameraFollow>().enabled = true;
        player.SetActive(false);
        smoke.SetActive(false);
        boatfixed.SetActive(true);
        boatbroken.SetActive(false);
    }
}
