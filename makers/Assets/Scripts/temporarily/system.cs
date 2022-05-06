using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class system : MonoBehaviour
{
    public GameObject escapePan;
    public GameObject keysettionPan;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            escapePan.SetActive(true);
        }
        else if(Input.GetKey(KeyCode.K)&&!escapePan.activeSelf)
        {
            keysettionPan.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void gameContinue()
    {
        escapePan.SetActive(false);
    }

    public void gameExit()
    {
        Application.Quit();
    }

    public void KS_cancel()
    {
        keysettionPan.SetActive(false);
        Time.timeScale = 1;
    }
}
