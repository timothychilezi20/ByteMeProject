using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    private float timer = 30f; 
    public TMP_Text timerText; 

    void Start()
    {
        UpdateTimerText();
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            
            Debug.Log("Time's up!");
            timer = 30f; 
            UpdateTimerText(); 
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);

        timerText.text = string.Format("Time remaining: {0:00}:{1:00}", minutes, seconds); 
    }
}