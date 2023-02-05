using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOverlay : MonoBehaviour
{
    // ScoreTextProperties scoreTextProperties;
    // Timer timer;
    Text levelScoreText;
    Canvas playerOverlayCanvas;
    bool isAdding = false;
    AudioManager audioManager;  


    public void SetUp()
    {
        playerOverlayCanvas = GetComponentInChildren<Canvas>();
        Text[] allTexts = GetComponentsInChildren<Text>();
        
        foreach(Text text in allTexts)
        {
            if(text.name == "ScoreText")
                levelScoreText = text;
        }
        
        // scoreTextProperties = GetComponentInChildren<ScoreTextProperties>();
        // timer = GetComponentInChildren<Timer>();
        // audioManager = GetComponentInParent<AudioManager>();

    }

    public void ResetOverlay()
    {
        // scoreTextProperties.ResetScore();
        levelScoreText.text = "Score: 0";
        // timer.ResetTotalTime();
    }



    public void UpdatePlayerOverlay(int levelScore)
    {
        // scoreTextProperties.UpdateScore(levelScore)
        levelScoreText.text = "Score: " + levelScore;
    }


    public void TogglePlayerOverlayCanvas(bool state)
    {
        playerOverlayCanvas.enabled = state;
    }

    // public void StartTimer(int startTime)
    // {
    //     StartCoroutine(timer.StartTimer());
    // }

    // public int GetTotalTime()
    // {
    //     return timer.GetTotalTime();
    // }
}
