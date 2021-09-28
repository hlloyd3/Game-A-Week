using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{

    public float maxSlowTimer;
    public float currentSlowTimer;
    public float playerSpeedScaler;
    public float enemySpeedScaler;
    public float musicSpeedScaler;
    private bool isSlowingTime = false;
    public Text slowTimerText;
    AudioSource bgMusic;
    private RipplePostProcessor camRipple;

    private void Start()
    {
        currentSlowTimer = maxSlowTimer;
        bgMusic = GetComponent<AudioSource>();
        camRipple = Camera.main.GetComponent<RipplePostProcessor>();
    }

    private void Update()
    {
        slowTimerText.text = "Spare Time: " + currentSlowTimer.ToString("F1");
        bgMusic.pitch = musicSpeedScaler;

        if (Input.GetKeyDown(KeyCode.E) && currentSlowTimer > 0)
        {
            ToggleTimeControl();
        }

        if (isSlowingTime)
        {
            currentSlowTimer -= Time.deltaTime;
            playerSpeedScaler = 0.75f;
            enemySpeedScaler = 0.3f;
            musicSpeedScaler = 0.85f;
        }
        else
        {
            playerSpeedScaler = 1;
            enemySpeedScaler = 1;
            musicSpeedScaler = 1;
        }

        if(currentSlowTimer <= 0)
        {
            isSlowingTime = false;
            slowTimerText.text = "Out of Spare Time!";
        }
    }

    void ToggleTimeControl()
    {
        isSlowingTime = !isSlowingTime;
        camRipple.CameraRipple();
    }

}
