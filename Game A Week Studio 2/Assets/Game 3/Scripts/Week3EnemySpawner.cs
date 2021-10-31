using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week3EnemySpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject enemyPrefab;
    public Week3ScoreManager scoreManager;
    public float timeBeforeNextEnemy;
    public float maxTime;

    public void Start()
    {
        timeBeforeNextEnemy = maxTime;
    }

    private void Update()
    {
        if (player.GetComponent<Week3PlayerController>().isPlaying)
        {
            transform.position = new Vector2(transform.position.x, player.transform.position.y);
            timeBeforeNextEnemy -= Time.deltaTime;
            if (timeBeforeNextEnemy <= 0)
            {
                SpawnEnemy();
            }
        }

        if (scoreManager.dist >= 100 && scoreManager.dist < 200)
        {
            maxTime = 4.5f;
        }
        else if (scoreManager.dist >= 200 && scoreManager.dist < 300)
        {
            maxTime = 4;
        }
        else if (scoreManager.dist >= 300 && scoreManager.dist < 400)
        {
            maxTime = 3.5f;
        }
        else if (scoreManager.dist >= 400)
        {
            maxTime = 3;
        }
    }

    public void SpawnEnemy()
    {
        float randomTime = Random.Range(3, maxTime);
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        timeBeforeNextEnemy = randomTime;
    }
}
