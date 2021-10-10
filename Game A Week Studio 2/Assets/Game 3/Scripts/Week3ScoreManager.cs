using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Week3ScoreManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI endText;
    public GameObject startPoint;
    public GameObject player;

    private void Update()
    {
        float dist = (startPoint.transform.position.x - player.transform.position.x) * -1;
        scoreText.text = "Distance flown: " + dist.ToString("F0") + "m";
        endText.text = "You flew for " + dist.ToString("F0") + "m before crashing!";
    }

}
