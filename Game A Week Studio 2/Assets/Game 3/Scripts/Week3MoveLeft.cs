using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week3MoveLeft : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.tag == "Destroyer")
        {
            Destroy(this.gameObject);
        }
    }

}
