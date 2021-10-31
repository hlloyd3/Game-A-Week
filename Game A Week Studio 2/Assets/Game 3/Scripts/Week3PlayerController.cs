using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week3PlayerController : MonoBehaviour
{

    public float speed;
    public float speedScale;
    public bool isPlaying = false;
    public float verticalForce;
    private Rigidbody2D rb;
    public Week3ScoreManager scoreManager;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speedScale = 1;
    }

    private void FixedUpdate()
    {
        if (isPlaying)
        {
            transform.Translate(Vector3.right * speed * speedScale * Time.deltaTime);
            if (Input.GetKey(KeyCode.Space))
            {
                rb.velocity = Vector2.up * verticalForce;
            }
        }       

        if(scoreManager.dist >= 100 && scoreManager.dist < 200)
        {
            speedScale = 1.3f;
        }
        else if(scoreManager.dist >= 200 && scoreManager.dist < 300)
        {
            speedScale = 1.6f;
        }
        else if(scoreManager.dist >= 300 && scoreManager.dist < 400)
        {
            speedScale = 2;
        }
        else if(scoreManager.dist >= 400)
        {
            speedScale = 2.5f;
        }
    }

    public void StartGame()
    {
        isPlaying = true;
    }

}
