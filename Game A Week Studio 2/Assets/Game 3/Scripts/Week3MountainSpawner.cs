using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week3MountainSpawner : MonoBehaviour
{

    public float timeBeforeNextMountain;
    public int maxTime;
    public GameObject player;

    public GameObject[] mountains;

    public void Start()
    {
        timeBeforeNextMountain = maxTime;
    }

    public void SpawnMountain()
    {
        float randomTime = Random.Range(5, maxTime);
        int randomMountain = Random.Range(0, mountains.Length);
        GameObject newMountain = Instantiate(mountains[randomMountain], transform.position, Quaternion.identity);
        timeBeforeNextMountain = randomTime;
    }

    public void Update()
    {
        if (player.GetComponent<Week3PlayerController>().isPlaying)
        {
            timeBeforeNextMountain -= Time.deltaTime;
            if (timeBeforeNextMountain <= 0)
            {
                SpawnMountain();
            }
        }
    }

}
