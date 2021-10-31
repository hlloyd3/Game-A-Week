using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week5LoseGame : MonoBehaviour
{

    public GameObject loseScreen;
    public GameObject player;
    public AudioSource music;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            LoseGame();
        }
    }

    public void LoseGame()
    {
        loseScreen.SetActive(true);
        player.GetComponent<Week5PlayerController>().isPlaying = false;
        music.Stop();
    }

}
