using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Trashspawner : MonoBehaviour
{
    public GameObject Plastic;
    public GameObject Metal;
    public GameObject Glass;
    public GameObject Paper;
    public int trashCount;
    
    void Start()
    {
        StartCoroutine(InitialSpawn());
    }
    void Update()
    {
        
    }

    GameObject getRandomMaterial()
    {
        var random = new System.Random();        
        var materialOptions = new List<GameObject>{
            Plastic, 
            Plastic, 
            Plastic, 
            Plastic,  // Frequency of plastic - 40%
            Paper,
            Paper,
            Paper, // Frequency of paper - 30%
            Glass, 
            Glass, // Frequency of glass - 20%
            Metal // Frequency of metal - 10%
        };
        int pickedIndex = random.Next(materialOptions.Count);
        
        return materialOptions[pickedIndex];
    }

    IEnumerator InitialSpawn()
    {        
        Instantiate(getRandomMaterial(), new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        Instantiate(getRandomMaterial(), new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        Instantiate(getRandomMaterial(), new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        trashCount = 3;
        
        while (trashCount < 5)
        {
            float timer = UnityEngine.Random.Range(5, 6);
            Instantiate(getRandomMaterial(), new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            trashCount++;
            yield return new WaitForSeconds(timer);
        }
    }
}
