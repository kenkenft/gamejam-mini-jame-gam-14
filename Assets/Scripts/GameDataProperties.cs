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

    public void SetTargetStageID(int targetID)
    {
        targetStageID = targetID;
    }

    public void UpdateLevelScore(int score)
    {
        levelScore += score;
    }

    public int GetLevelScore()
    {
        return levelScore;
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
