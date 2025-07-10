using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timeText;
    float score = 0;
    bool timerRunning = false;
    float timeToDeliver = 15;
    float packageTimer; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "Score: 0";
        packageTimer = timeToDeliver;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerRunning)
        {
            packageTimer -= 1f * Time.deltaTime;
            
        }
        updateText();
    }
    public void packageDelivered()
    {
        score += Mathf.RoundToInt(packageTimer);
        scoreText.text = "Score: " + score;
        restTimer();
    }
    public void AddScore(float amount)
    {
        score += amount;
        updateText();
    }

    void updateText()
    {
        scoreText.text = "Score: " + score;
        int timerRound = Mathf.RoundToInt(packageTimer);
        timeText.text = "Time: " + timerRound.ToString() + "s";
    }
    public void startTimer()
    {
        timerRunning = true;
    }
    void restTimer()
    {
        timerRunning = false;
        packageTimer = timeToDeliver;
        
    }
}
