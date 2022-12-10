using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashspawner : MonoBehaviour
{
    public int trashcount;
    public GameObject Plastic;
    public GameObject metal;
    public GameObject glass;
    public GameObject paper;
    public int type;
    void Start()
    {
        StartCoroutine(Spawn());
    }
    void Update()
    {
        
    }
    IEnumerator Spawn()
    {
        while (trashcount < 1)
        {
            float timer = Random.Range(5, 6);
            switch (type)
            {
                case 0:
                    Instantiate(Plastic, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                    break;
                case 1:
                    Instantiate(glass, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                    break;
            }
            trashcount++;
            yield return new WaitForSeconds(timer);
        }
    }
}
