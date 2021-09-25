using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Vector2 moveDirection;
    public float moveSpeed;
    private float currentMoveSpeed;
    public GameObject speedController;
    private float speedScale;

    private void Start()
    {
        speedController = GameObject.Find("SpeedManager");
        Debug.Log(speedController.ToString());
    }

    private void OnEnable()
    {
        Invoke("DestroySelf", 3f);
    }

    private void Update()
    {
        speedScale = speedController.GetComponent<TimeController>().enemySpeedScaler;
        currentMoveSpeed = moveSpeed * speedScale;
        transform.Translate(moveDirection * currentMoveSpeed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    private void DestroySelf()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Enemy")
        {
            DestroySelf();
        }
        if(collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealthController>().LoseHealth();
        }
    }

}
