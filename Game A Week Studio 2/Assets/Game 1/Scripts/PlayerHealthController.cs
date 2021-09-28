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

    public SpriteRenderer[] bodyParts;
    public Color hurtColor;

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
        StartCoroutine(Flash());
        currentHealth -= 1;
    }

    IEnumerator Flash()
    {
        for (int i = 0; i < bodyParts.Length; i++)
        {
            bodyParts[i].color = hurtColor;
        }
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < bodyParts.Length; i++)
        {
            bodyParts[i].color = Color.white;
        }
    }

    public void KillPlayer()
    {
        Destroy(player);
        deathScreen.SetActive(true);
    }

}
