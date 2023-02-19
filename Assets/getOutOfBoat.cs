using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getOutOfBoat : MonoBehaviour
{
    public GameObject boat;
    public GameObject player;

    private bool closeEnough;

    void Update()
    {
        closeEnough = false;
        if (Vector3.Distance(player.transform.position, transform.position) <= 10)
        {
            closeEnough = true;
        }

        if (Input.GetMouseButtonDown(0) && closeEnough)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "Land1")
                {
                    player.transform.position = new Vector3(-0.56f, 7.06f, 12.16f);
                    boat.GetComponent<clickMove>().enabled = false;
                    boat.GetComponent<getInBoat>().setPlayerInBoat(false);
                    player.SetActive(true);

                    FindObjectOfType<AudioManager>().Stop("boat");
                    FindObjectOfType<AudioManager>().Play("theme");
                }
            }
        }
    }
}
