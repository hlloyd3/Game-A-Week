using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week3DestroySelf : MonoBehaviour
{

    public float timer;

    private void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
