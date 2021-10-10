using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week3Enemy : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Week3LoseGame>().LoseGame();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Destroyer")
        {
            Destroy(this.gameObject);
        }
    }

}
