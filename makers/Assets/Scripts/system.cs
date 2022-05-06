using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class system : MonoBehaviour
{
    public Canvas canvas;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            canvas.enabled = true;
        }
    }

    public void gameContinue()
    {
        canvas.enabled = false;        
    }

    public void gameExit()
    {
        Application.Quit();
    }
}
