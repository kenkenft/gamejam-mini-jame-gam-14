using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Data Properties")]
public class GameDataProperties : ScriptableObject
{
    [SerializeField] int targetStageID, playerScore = 0;

    public void SetTargetStageID(int targetID)
    {
        targetStageID = targetID;
    }

    public void SetPlayerScore(int score)
    {
        playerScore += score;
    }

    public void ResetGameDataProperties()
    {
        playerScore = 0;
    }
}
