using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{

    public float timeBeforeNextCloud;
    public float maxTime;

    public GameObject[] clouds;

    public void Start()
    {
        timeBeforeNextCloud = maxTime;
    }

    public void SpawnCloud()
    {
        float randomSpeed = Random.Range(1, 5);
        float randomTime = Random.Range(1, maxTime);
        int randomCloud = Random.Range(0, clouds.Length);

        GameObject newCloud = Instantiate(clouds[randomCloud], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        newCloud.GetComponent<Week3MoveLeft>().speed = randomSpeed;
        timeBeforeNextCloud = randomTime;
    }

    public void RandomisePosition()
    {
        float randomPosition = Random.Range(-20, 20);
        Debug.Log(randomPosition);
        transform.position = new Vector2(transform.position.x, randomPosition);
    }

    public void Update()
    {
        timeBeforeNextCloud -= Time.deltaTime;

        if(timeBeforeNextCloud <= 0)
        {
            SpawnCloud();
            RandomisePosition();
        }
    }

}
