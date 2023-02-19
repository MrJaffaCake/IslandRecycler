using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// dodadi na kamerata
//
// za dvizenje na kamerata so igracot (so granici):
// player.position.x, [od x koordinata]f, [do x koorinata]f
// istoto za z
//

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(player.position.x, 16f, 38f), transform.position.y, Mathf.Clamp(player.position.z, -21f, 5f));
    }
}
