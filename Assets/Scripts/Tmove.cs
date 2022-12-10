using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tmove : MonoBehaviour
{
    public Transform Node;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 dir = (Node.position - this.transform.position);
        this.transform.position += dir * 0.2f * Time.deltaTime;
    }
}