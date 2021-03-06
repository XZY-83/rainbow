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
    int dashCount = 1;
    bool isDash = false;    
    
    Rigidbody2D rigid;
    SpriteRenderer sprite;
    Animator animator;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        HorizantalMove();
        dash();
        Jump();
    }

    void HorizantalMove()  //수평움직임
    {
        if (Input.GetKey(KeySetting.keys[KeyAction.LEFT]))
        {
            sprite.flipX = true;
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeySetting.keys[KeyAction.RIGHT]))
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

        if (!isGround)
            animator.SetTrigger("jump");

        if (Input.GetKeyDown(KeySetting.keys[KeyAction.JUMP]) && Input.GetKey(KeySetting.keys[KeyAction.DOWN]) && isGround)
        {
            GameObject.FindWithTag("DownPlatform").GetComponent<DownPlatform>().ChangeLayer();
            jumpCount = 0;
        }
        else if (Input.GetKeyDown(KeySetting.keys[KeyAction.JUMP]) && jumpCount > 0)
            rigid.velocity = new Vector2(rigid.velocity.x, jumpspeed);

        if (Input.GetKeyUp(KeySetting.keys[KeyAction.JUMP]))
            jumpCount--;


    }

    void dash()
    {
        if (isGround)
            dashCount = 1;

        if (Input.GetKeyDown(KeySetting.keys[KeyAction.DASH]) && dashCount > 0)
            isDash = true;

        if (isDash)
        {
            rigid.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

            if (sprite.flipX)
                transform.position += Vector3.left * speed * dashSpeed * Time.deltaTime;
            else
                transform.position += Vector3.right * speed * dashSpeed * Time.deltaTime;

            if(!isGround)
                dashCount--;

            animator.SetTrigger("dash");
            StartCoroutine(stopDash());
        }
    }

    IEnumerator stopDash()
    {
        yield return new WaitForSeconds(0.2f);
        rigid.constraints = RigidbodyConstraints2D.FreezeRotation;

        isDash = false;
    }

}
