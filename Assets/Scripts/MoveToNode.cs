using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToNode : MonoBehaviour
{
    public GameObject node1;
    public GameObject node2;
    public GameObject node3;
    public GameObject node4;
    public GameObject node5;
    GameObject Truenode;
    int node;
    public bool lookat;
    public bool move;
    void Start()
    {
        lookat = true;
        move = true;
        node = Random.Range(0, 5);
        switch (node)
        {
            case 0:
                Truenode = node1;
                break;
            case 1:
                Truenode = node2;
                break;
            case 2:
                Truenode = node3;
                break;
            case 3:
                Truenode = node4;
                break;
            case 4:
                Truenode = node5;
                break;
        }
            
    }
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Truenode.transform.position);
        if (lookat)
            transform.LookAt(Truenode.transform.position);
        if (move == true)
        {
            Vector3 dir = (Truenode.transform.position - this.transform.position);
            this.transform.position += dir * 0.2f * Time.deltaTime;
        }
        else if(distance > 0.1f)
            if(distance < 0.9f)
            {
                move = false;
                lookat = false;
            }
    }
}
