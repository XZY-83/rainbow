using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Move Speed")]
    public float speed = 8f;
    public float dashSpeed = 15f;
    public float jumpspeed = 8f;

    float jumpCount = 2;

    bool isGround = false;
    public bool isDash = false;
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
        dash();
        Jump();
    }

    void HorizantalMove()  //수평움직임
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            sprite.flipX = true;
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            sprite.flipX = false;
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }
    void dash()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            isDash = true;

        if (isDash)
        {
            if (sprite.flipX)
                transform.position += Vector3.left * speed * dashSpeed * Time.deltaTime;
            else
                transform.position += Vector3.right * speed * dashSpeed * Time.deltaTime;

            StartCoroutine(stopDash());
        }
    }

    IEnumerator stopDash()
    {
        yield return new WaitForSeconds(0.2f);
        isDash = false;
    }

    void Jump()  //점프
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isGround)  //착지했을 때만 점프
            {
                if(jumpCount==2)
                    rigid.velocity=new Vector2(rigid.velocity.x, jumpspeed);
                else if(jumpCount==1)
                    rigid.velocity = new Vector2(rigid.velocity.x, jumpspeed);

                jumpCount--;
            }

            if(jumpCount == 0)
                isGround = false;
        }


        /*if (Input.GetKeyDown(KeyCode.Space) && Input.GetButton("Vertical"))
        {
            GameObject.FindWithTag("DownPlatform").GetComponent<DownPlatform>().ChangeLayer();
        }*/
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground"|| collision.gameObject.tag == "DownPlatform")
        {
            isGround = true;
            jumpCount = 2;
        }
    }
}
