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
    SpriteRenderer sprite;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        HorizantalMove();
        Jump();
    }

    void HorizantalMove()  //���������
    {
        if (Input.GetAxisRaw("Horizontal")<0)
        {
            sprite.flipX = true;
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            sprite.flipX = false;
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }

    void Jump()  //����
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)  //�������� ���� ����
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
