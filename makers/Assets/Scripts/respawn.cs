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
        if(player.transform.position.y<-8) //떨어졌을때
        {
            player.transform.position = this.transform.position; //떨어진 곳 근처에 리스폰
        }    
    }
}
