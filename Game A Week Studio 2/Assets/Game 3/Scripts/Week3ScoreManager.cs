using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Week3ScoreManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    
    public GameObject startPoint;
    public GameObject player;
    public float dist;

    private void Update()
    {
        dist = (startPoint.transform.position.x - player.transform.position.x) * -1;
        scoreText.text = "Distance flown: " + dist.ToString("F0") + "m";
        
    }

}
