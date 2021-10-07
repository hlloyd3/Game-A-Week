using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBullet : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision!");
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.position += transform.right * 0.25f;
    }
}
