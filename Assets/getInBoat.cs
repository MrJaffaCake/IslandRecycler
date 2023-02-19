using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getInBoat : MonoBehaviour
{
    public GameObject trashSpawners;
    public GameObject player;
    public GameObject fixedBoat;
    public GameObject camera;

    private bool closeEnough, playerInBoat = false;

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
                if (hit.transform.gameObject.tag == "fixedboat" && !playerInBoat)
                {
                    trashSpawners.SetActive(true);
                    camera.GetComponent<CameraFollow>().enabled = true;
                    fixedBoat.GetComponent<clickMove>().enabled = true;
                    player.SetActive(false);
                    playerInBoat = true;

                    FindObjectOfType<AudioManager>().Stop("theme");
                    FindObjectOfType<AudioManager>().Play("boat");
                    
                }
            }
        }
    }

    public bool getPlayerInBoat()
    {
        return playerInBoat;
    }

    public void setPlayerInBoat(bool p)
    {
        playerInBoat = p;
    }
}
