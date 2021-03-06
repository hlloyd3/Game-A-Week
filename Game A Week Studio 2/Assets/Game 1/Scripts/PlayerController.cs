using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed;
    private float moveInput;
    public float jumpForce;

    private bool isGrounded;
    private bool isJumping;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask ground;

    private float currentJumpTime;
    public float maxJumpTime;

    public GameObject speedController;
    private float speedScale;
    public int gravity;

    public GameObject winScreen;

    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed * speedScale, rb.velocity.y);
        rb.gravityScale = gravity * speedScale;
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, ground);

        speedScale = speedController.GetComponent<TimeController>().playerSpeedScaler;

        if(moveInput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }

        if(moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if( moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("TakeOff");
            isJumping = true;
            currentJumpTime = maxJumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (isGrounded)
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (currentJumpTime > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                currentJumpTime -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EndPoint")
        {
            Debug.Log("You Win!");
            winScreen.SetActive(true);
            GetComponent<BoxCollider2D>().gameObject.SetActive(false);
            GetComponent<PlayerController>().gameObject.SetActive(false);
        }
    }

}
