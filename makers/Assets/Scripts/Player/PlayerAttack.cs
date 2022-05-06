using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    float curTime;
    public float coolTime = 0.5f;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        Attack();    
    }

    void Attack()
    {
        if (curTime <= 0)
        {
            if (Input.GetKey(KeyCode.X))
            {
                animator.SetTrigger("attack");
                curTime = coolTime;
            }
        }
        else
        {
            curTime -= Time.deltaTime;
        }
    }
}
