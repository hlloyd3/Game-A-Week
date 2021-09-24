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

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

        if(moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if( moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            currentJumpTime = maxJumpTime;
            rb.velocity = Vector2.up * jumpForce;
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

}
