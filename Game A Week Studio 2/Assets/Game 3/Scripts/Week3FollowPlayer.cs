using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week3FollowPlayer : MonoBehaviour
{

    public GameObject player;

    private void Update()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }

}
