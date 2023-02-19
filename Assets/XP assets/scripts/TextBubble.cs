using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBubble : MonoBehaviour
{

    void FixedUpdate()
    {
        StartCoroutine(DisappearTxt());
    }

    private IEnumerator DisappearTxt()
    {
        yield return new WaitForSeconds(4);
        this.gameObject.SetActive(false);
        yield return null;
    }
    
}
