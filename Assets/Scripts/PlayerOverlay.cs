using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using TMPro;

public class PlayerOverlay : MonoBehaviour
{
    public GameObject[] trucks = new GameObject[4];
    ScoreTextProperties scoreTextProperties;
    Timer timer;
    Canvas playerOverlayCanvas;
    int fillAmount = 1;
    bool isAdding = false;
    List<int> deliveredFruitsList = new List<int>{};
    AudioManager audioManager;  


    public void SetUp()
    {
        playerOverlayCanvas = GetComponentInChildren<Canvas>();
        
        scoreTextProperties = GetComponentInChildren<ScoreTextProperties>();
        timer = GetComponentInChildren<Timer>();
        
        
        audioManager = GetComponentInParent<AudioManager>();

    }

    public void ResetOverlay()
    {
        scoreTextProperties.ResetScore();
        timer.ResetTotalTime();
    }


    char ParseHarvestCharacter(string stringInput)
    {
        char parsedString = 'a';
        foreach(char letter in stringInput)
        {
            if(letter.Equals('a') || letter.Equals('s') || letter.Equals('d') || letter.Equals('f'))
                parsedString = letter;
        }
        return parsedString;
    }


    public int GetFinalScore()
    {
        return scoreTextProperties.GetCurrentScore();
    }


    public void TogglePlayerOverlayCanvas(bool state)
    {
        playerOverlayCanvas.enabled = state;
    }

    public void StartTimer(int startTime)
    {
        StartCoroutine(timer.Countdown(startTime));
    }

    public int GetTotalTime()
    {
        return timer.GetTotalTime();
    }
}
