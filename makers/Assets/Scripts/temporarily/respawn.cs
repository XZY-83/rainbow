using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            return;
        if(player.transform.position.y<-8) //����������
        {
            player.transform.position = this.transform.position; //������ �� ��ó�� ������
        }    
    }
}
