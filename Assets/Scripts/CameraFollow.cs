using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private void Start()
    {
        transform.position = new Vector3(-2.92f, transform.position.y, transform.position.z);
    }
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(player.position.x, -6.15f, 9999999f),
            transform.position.y,
            transform.position.z);
    }
}
