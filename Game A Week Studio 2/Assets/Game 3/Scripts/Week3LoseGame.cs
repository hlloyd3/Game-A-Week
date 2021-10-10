using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week3LoseGame : MonoBehaviour
{
    public GameObject LoseScreen;
    public GameObject player;

    public void LoseGame()
    {
        Debug.Log("You Lose!");
        LoseScreen.SetActive(true);
        player.GetComponent<Week3PlayerController>().isPlaying = false;
    }
}
