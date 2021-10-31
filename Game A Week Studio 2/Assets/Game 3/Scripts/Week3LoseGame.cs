using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Week3LoseGame : MonoBehaviour
{
    public GameObject LoseScreen;
    public GameObject player;
    public GameObject scoreManager;
    public TextMeshProUGUI endText;

    public void LoseGame()
    {
        Debug.Log("You Lose!");
        LoseScreen.SetActive(true);
        player.GetComponent<Week3PlayerController>().isPlaying = false;
        float finalScore = scoreManager.GetComponent<Week3ScoreManager>().dist;
        endText.text = "You flew for " + finalScore.ToString("F0") + "m before crashing!";
    }
}
