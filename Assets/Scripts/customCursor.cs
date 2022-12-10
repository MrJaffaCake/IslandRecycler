using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class customCursor : MonoBehaviour
{  
     public void Awake(){
       transform.position = Input.mousePosition;
    

   }

   public void Update(){
       transform.position = Input.mousePosition;
    

   }


}