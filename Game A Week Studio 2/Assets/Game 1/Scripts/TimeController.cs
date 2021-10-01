using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeController : MonoBehaviour
{

    public float maxSlowTimer;
    public float currentSlowTimer;
    public float playerSpeedScaler;
    public float enemySpeedScaler;
    public float musicSpeedScaler;
    private bool isSlowingTime = false;
    public TextMeshProUGUI slowTimerText;
    AudioSource bgMusic;
    private RipplePostProcessor camRipple;
    public Animator anim;
    public Slider slider;

    private void Start()
    {
        currentSlowTimer = maxSlowTimer;
        bgMusic = GameObject.Find("musicManager").GetComponent<AudioSource>();
        camRipple = Camera.main.GetComponent<RipplePostProcessor>();
    }

    private void Update()
    {
        slowTimerText.text = "Spare Time:";
        bgMusic.pitch = musicSpeedScaler;
        SetTimerSlider(currentSlowTimer);

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
            anim.speed = 1;
        }
        else
        {
            playerSpeedScaler = 1;
            enemySpeedScaler = 1;
            musicSpeedScaler = 1;
            anim.speed = 0;
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

    public void SetTimerSlider(float time)
    {
        slider.value = time;
    }

}
