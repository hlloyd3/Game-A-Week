using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week5PlayerController : MonoBehaviour
{

    public Rigidbody rb;
    public float speed;
    public float horizontalMultiplier;
    public bool isPlaying = true;

    float horizontalInput;

    private void FixedUpdate()
    {
        if (isPlaying)
        {
            Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
            Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
            rb.MovePosition(rb.position + forwardMove + horizontalMove);
        }
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

}
