using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private float enemyHealth;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private int killReward;

    [SerializeField]
    private int damage;

    private GameObject targetTile;

    private MoneyManager moneyManager;
    private LivesManager livesManager;

    private void Awake()
    {
        Enemies.enemies.Add(gameObject);
    }

    private void Start()
    {
        initializeEnemy();
        moneyManager = GameObject.Find("MoneyManager").GetComponent<MoneyManager>();
        livesManager = GameObject.Find("LivesManager").GetComponent<LivesManager>();
    }

    private void initializeEnemy()
    {
        targetTile = MapGenerator.startTile;
    }

    public void takeDamage(float amount)
    {
        enemyHealth -= amount;

        if(enemyHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Enemies.enemies.Remove(gameObject);
        moneyManager.AddMoney(killReward);
        Destroy(transform.gameObject);
    }

    private void DamageCrystal()
    {
        Enemies.enemies.Remove(gameObject);
        livesManager.LoseLives(damage);
        Destroy(transform.gameObject);
    }

    private void moveEnemy()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetTile.transform.position, moveSpeed * Time.deltaTime);
    }

    private void checkPosition()
    {
        if(targetTile != null && targetTile != MapGenerator.endTile)
        {
            float distance = (transform.position - targetTile.transform.position).magnitude;

            if(distance < 0.001f)
            {
                int currentIndex = MapGenerator.pathTiles.IndexOf(targetTile);

                targetTile = MapGenerator.pathTiles[currentIndex + 1];
            }
        }

        if(transform.position == MapGenerator.endTile.transform.position)
        {
            DamageCrystal();
        }
    }

    private void Update()
    {
        checkPosition();
        moveEnemy();
    }

}
