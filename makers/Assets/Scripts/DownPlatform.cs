using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownPlatform : MonoBehaviour
{


    public void ChangeLayer()
    {
        gameObject.layer = 7;  //7=downplatform 
        StartCoroutine("ReturnLayer");
    }
    IEnumerator ReturnLayer() 
    { 
        yield return new WaitForSeconds(0.4f); 
        gameObject.layer = 6; 
    }
}
