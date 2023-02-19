using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterShop : MonoBehaviour
{
    public GameObject Player, shopWindow;
    private bool closeEnough;

    void Update()
    {
        closeEnough = false;
        if (Vector3.Distance(Player.transform.position, transform.position) <= 3)
        {
            closeEnough = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                BoxCollider b = hit.collider as BoxCollider;
                if (b != null && closeEnough)
                {
                    FindObjectOfType<AudioManager>().Play("ButtonPress");
                    
                    FindObjectOfType<AudioManager>().Stop("theme");
                    FindObjectOfType<AudioManager>().Play("shop");
                    
                    shopWindow.SetActive(true);
                }
            }
        }
    }
}
