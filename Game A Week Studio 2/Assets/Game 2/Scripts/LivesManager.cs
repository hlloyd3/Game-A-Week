using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    private int currentLives;

    public Text livesText;

    public int starterLives;

    public GameObject loseScreen;

    public int GetCurrentLives()
    {
        return currentLives;
    }

    public void Start()
    {
        currentLives = starterLives;
    }

    public void LoseLives(int amount)
    {
        currentLives -= amount;
    }

    public void LoseGame()
    {
        loseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void Update()
    {
        livesText.text = currentLives + " remaining!";

        if(currentLives <= 0)
        {
            LoseGame();
        }
    }
}
