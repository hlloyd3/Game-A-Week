using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week3Parallax : MonoBehaviour
{

    private float length;
    private float startPosition;
    public float offset;
    public GameObject cam;
    public float parallaxEffect;

    private void Start()
    {
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startPosition + dist, transform.position.y, transform.position.z);

        if(temp > startPosition + (length - offset))
        {
            startPosition += length;
        }
        else if(temp < startPosition - (length - offset))
        {
            startPosition -= length;
        }
    }

}
