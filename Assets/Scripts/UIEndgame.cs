using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 

public class UIEndgame : MonoBehaviour
{
    
    Canvas uIEndgameCanvas;
    Text playerScoreText, totalTimeText, totalFruitText;
    Button restartButton, mainMenuButton;
    Button[] allButtons;
    public GameObject fruitInfo, fruitDeliveredBreakdown;
    List<GameObject> fruitInfoList = new List<GameObject>{};
 
    public void SetUp()
    {
        uIEndgameCanvas = GetComponentInChildren<Canvas>();
        
        SetUpTextRefs();
        SetUpButtonRefs();
        ToggleButtonEnabled(true);
    }

    void SetUpTextRefs()
    {
        Text[] allTexts = GetComponentsInChildren<Text>();
        
        foreach(Text text in allTexts)
        {
            switch(text.name)
            {
                case "PlayerScoreText":
                {
                    playerScoreText = text;
                    break;
                }
                case "TotalTimeText":
                {
                    totalTimeText = text;
                    break;
                }
                case "TotalFruitText":
                {
                    totalFruitText = text;
                    break;
                }
                default: 
                    break;
            }
        }
    }

    void SetUpButtonRefs()
    {
        allButtons = GetComponentsInChildren<Button>();
        foreach(Button button in allButtons)
        {
            if(button.name == "RestartButton")
                restartButton = button;
            else
                mainMenuButton = button;
        }
    }

    public void ToggleEndgameCanvas(bool state)
    {
        ToggleButtonEnabled(state);
        uIEndgameCanvas.enabled = state;
    }

    public void SetPlayerScoreText(int finalScore)
    {
        string tempString = finalScore + " points";
        playerScoreText.text = tempString;
    }

    public void SetTotalTime(int totalTime)
    {
        string[] buffers = {"", ":", ":"};
        // Using integer division and discarding the remainder for hours and minutes, whereas seconds keeps the remainder instead.
        int hours = totalTime/3600,
            tempIntA = totalTime - (hours * 3600), 
            minutes = tempIntA / 60,
            seconds = tempIntA % 60;
        
        if(hours < 10)
            buffers[0] = "0";
        if(minutes < 10)
            buffers[1] = ":0";
        if(seconds < 10)
            buffers[2] = ":0";

        string tempString;
        if(totalTime >= 86400)
            tempString = "Far too long";
        else
            tempString = buffers[0] + hours + buffers[1] + minutes + buffers[2] + seconds;
        totalTimeText.text = tempString;
    }

    public void SetTotalFruitText(int totalFruit)
    {
        string tempString = totalFruit + "";
        totalFruitText.text = tempString;
    }


    public void ToggleButtonEnabled(bool state)
    {
        foreach(Button button in allButtons)
        {
            button.interactable = state;
        }
    }
}
