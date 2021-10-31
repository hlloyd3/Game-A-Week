using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week5FollowCamera : MonoBehaviour
{

    public GameObject cameraPos;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, cameraPos.transform.position.z);
    }

}
