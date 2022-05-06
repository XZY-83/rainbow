using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowTarget : MonoBehaviour
{
    Transform target;
    public float speed = 1f;

    Vector3 direction;

    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("Player") != null)
            target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        decideEnemyDirection();
        MoveToTarget();
    }

    void decideEnemyDirection()
    {
        if (target != null) return;

        var dir = target.position.x - transform.position.x;
        GetComponent<SpriteRenderer>().flipX = (dir < 0) ? true : false;
    }

    void MoveToTarget()
    {
        if(GameObject.FindGameObjectWithTag("Player")!=null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            direction=target.position - transform.position;
        }
        int dir = (direction.x <= 0) ? -1 : 1;
        GetComponent<Rigidbody2D>().velocity
            = new Vector2(speed * direction.x, GetComponent<Rigidbody2D>().velocity.y);
    }

}
