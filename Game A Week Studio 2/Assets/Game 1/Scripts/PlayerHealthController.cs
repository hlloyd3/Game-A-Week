using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;

    public Image[] hearts;
    public Sprite emptyHeart;
    public Sprite fullHeart;

    public GameObject player;
    public GameObject deathScreen;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        if (currentHealth <= 0)
        {
            KillPlayer();
        }
    }

    public void LoseHealth()
    {
        currentHealth -= 1;
    }

    public void KillPlayer()
    {
        Destroy(player);
        deathScreen.SetActive(true);
    }

}
