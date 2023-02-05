using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Data Properties")]
public class GameDataProperties : ScriptableObject
{
    [SerializeField] int targetStageID, 
                         levelScore, totalScore, 
                         totalTime, levelTime, 
                         totalMistakes, levelMistakes;

    void OnEnable()
    {
        // ResetGameDataProperties(); // If data is not saving between scenes, it could be this line
    }

    void OnDisable()
    {
        ResetGameDataProperties(); // If data is not saving between scenes, it could be this line
    }
    
    public void SetTargetStageID(int targetID)
    {
        targetStageID = targetID;
    }

    public int GetGameData(string targetData)
    {
        switch(targetData)
        {
            case "levelScore":
                return levelScore;
            case "totalScore":
                return totalScore;
            case "levelTime":
                return levelTime;
            case "totalTime":
                return totalTime;
            case "levelMistakes":
                return levelMistakes;
            case "totalMistakes":
                return totalMistakes;
            default:
                return 0;
        }
    }

    public void UpdateGameData(int value ,string targetData)
    {
        switch(targetData)
        {
            case "levelScore":
            {
                levelScore += value;
                break;
            }
            case "totalScore":
            {
                totalScore += levelScore;
                break;
            }
            case "levelTime":
            {
                levelTime += value;
                break;
            }
            case "totalTime":
            {
                totalTime += value;
                break;
            }
            case "levelMistakes":
            {
                levelMistakes += value;
                break;
            }
            case "totalMistakes":
            {
                totalMistakes += value;
                break;
            }
            default:
                break;
        }
    }

    public void UpdateTotalScore(int score)
    {
        totalScore += score;
    }

    public void ResetGameDataProperties()
    {
        ResetLevelDataProperties();
        totalScore = 0;
        totalTime = 0;  
        totalMistakes = 0;
    }

    public void ResetLevelDataProperties()
    {
        levelScore = 0; 
        levelTime = 0;
        levelMistakes = 0;
    }
}
