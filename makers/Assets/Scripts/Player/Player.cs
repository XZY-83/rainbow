using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Move Speed")]
    public float speed = 8f;
    public float dashSpeed = 15f;
    public float jumpspeed = 8f;
    public bool isGround = false;

    [SerializeField] private Transform pos;
    [SerializeField] LayerMask islayer;
    
    int jumpCount = 2;
    bool isDash = false;    
    
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
    void Jump()  //점프
    {
        isGround = Physics2D.OverlapCircle(pos.position, 0.1f, islayer);


        if (isGround)
            jumpCount = 2;
        
        if (Input.GetKeyDown(KeyCode.C) && Input.GetKey(KeyCode.DownArrow) && isGround)
        {
            GameObject.FindWithTag("DownPlatform").GetComponent<DownPlatform>().ChangeLayer();
            jumpCount = 0;
        }
        else if (Input.GetKeyDown(KeyCode.C) && jumpCount > 0)
            rigid.velocity = new Vector2(rigid.velocity.x, jumpspeed);

        if (Input.GetKeyUp(KeyCode.C))
            jumpCount--;


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

}
