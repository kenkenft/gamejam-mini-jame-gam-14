using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FlagManager : MonoBehaviour
{
    public GameObject flagPrefab;
    public Transform[] flagsPositions;
    FlagProperties flagProperties;
    // GameManager gameManager;
    GameDataProperties gameDataProperties;
    LevelProperties levelProperties;
    [SerializeField] List<int> collectedFlagSequence = new List<int>{};
    int totalFlags = 0;
    // int[] pointValuesStart;

    public void SetUp(GameDataProperties instance)
    {
        gameDataProperties = instance;
        levelProperties = new LevelProperties();
        // gameManager = GetComponentInParent<GameManager>();
        totalFlags = flagsPositions.Length;

        int[] pointValuesStart = levelProperties.GetLevelFlagsPoints(gameDataProperties.GetGameData("targetStageID"));
        
        for(int i = 0; i < totalFlags; i++)
        {
            GameObject flagInstance = Instantiate(flagPrefab, flagsPositions[i].position, flagsPositions[i].rotation, flagsPositions[i]);
            
            flagProperties = flagInstance.GetComponent<FlagProperties>();
            flagProperties.SetUp(i, pointValuesStart[i]);
            flagProperties.SetFlagManager(this);
        }

        
    } 

    public void RecordFlagOrder(int flagID)
    {
        collectedFlagSequence.Add(flagID);
        if(collectedFlagSequence.Count >= totalFlags)
            gameObject.SendMessageUpwards("UnlockExitZone", 0, SendMessageOptions.RequireReceiver);
            // gameManager.UnlockExitZone(0);
    }

    public bool CheckReverseOrder(int flagID)
    {
        if(totalFlags > 0 && flagID == collectedFlagSequence[totalFlags - 1])
        {
            totalFlags--;
            if(totalFlags <= 0)
            gameObject.SendMessageUpwards("UnlockExitZone", 1);
                // gameManager.UnlockExitZone(1);

            // Debug.Log("Correct flag picked up!");
            return true;
        }
        gameDataProperties.UpdateGameData(1, "levelMistakes");
        // Debug.Log("Wrong flag picked up! Pick up flag: " + collectedFlagSequence[totalFlags - 1]);
        return false;
    }

    public void ModifyScore(int pointValue)
    {
        gameDataProperties.UpdateGameData(pointValue, "levelScore");
        gameObject.SendMessageUpwards("UpdatePlayerOverlay");
        // gameManager.UpdatePlayerOverlay();
    }
}
