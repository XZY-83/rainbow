using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Move Speed")]
    public float speed = 8f;
    public float jumpspeed = 8f;

    bool grounded = false;
    Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        HorizantalMove();
        Jump();
    }

    void HorizantalMove()  //수평움직임
    {
        if (Input.GetKey(KeyCode.A))
            transform.position += Vector3.left * speed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.D))
            transform.position += Vector3.right * speed * Time.deltaTime;
    }

    void Jump()  //점프
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)  //착지했을 때만 점프
            {
                rigid.velocity=new Vector2(rigid.velocity.x, jumpspeed);
                grounded = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Ground")
            grounded = true;
    }
}
