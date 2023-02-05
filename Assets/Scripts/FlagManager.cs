using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FlagManager : MonoBehaviour
{
    public GameObject flagPrefab;
    public Transform[] flagsPositions;
    FlagProperties flagProperties;
    GameManager gameManager;
    LevelProperties levelProperties;
    [SerializeField] List<int> collectedFlagSequence = new List<int>{};
    int totalFlags = 0;
    // int[] pointValuesStart;

    public void SetUp()
    {
        levelProperties = new LevelProperties();
        gameManager = GetComponentInParent<GameManager>();
        totalFlags = flagsPositions.Length;

        int[] pointValuesStart = levelProperties.GetLevelFlagsPoints(0);
        foreach(int point in pointValuesStart)
        {
            Debug.Log(point);
        }
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
            gameManager.UnlockExitZone(0);
    }

    public bool CheckReverseOrder(int flagID)
    {
        if(totalFlags > 0 && flagID == collectedFlagSequence[totalFlags - 1])
        {
            totalFlags--;
            if(totalFlags <= 0)
                gameManager.UnlockExitZone(1);

            // Debug.Log("Correct flag picked up!");
            return true;
        }

        // Debug.Log("Wrong flag picked up! Pick up flag: " + collectedFlagSequence[totalFlags - 1]);
        return false;
    }
}
