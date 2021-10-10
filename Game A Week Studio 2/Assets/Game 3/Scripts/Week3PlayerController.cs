using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week3PlayerController : MonoBehaviour
{

    public float speed;
    public bool isPlaying;
    public float verticalForce;
    private Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (isPlaying)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (Input.GetKey(KeyCode.Space))
            {
                rb.velocity = Vector2.up * verticalForce;
            }
        }
        else if (!isPlaying)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isPlaying = true;
            }
        }
    }

}
