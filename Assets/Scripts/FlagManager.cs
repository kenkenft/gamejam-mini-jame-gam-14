using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagManager : MonoBehaviour
{
    public GameObject flagPrefab;
    public Transform[] flagsPositions;
    FlagProperties flagProperties;
    GameManager gameManager;
    [SerializeField] List<int> collectedFlagSequence = new List<int>{};
    int totalFlags = 0, leftToCheck = 0;
    int[] pointValuesStart = {100, 200, 300, 400, 500, 600, 700};

    public void SetUp()
    {
        gameManager = GetComponentInParent<GameManager>();
        totalFlags = flagsPositions.Length;
        for(int i = 0; i < totalFlags; i++)
        {
            GameObject flagInstance = Instantiate(flagPrefab, flagsPositions[i].position, flagsPositions[i].rotation, flagsPositions[i]);
            
            flagProperties = flagInstance.GetComponent<FlagProperties>();
            flagProperties.SetUp(i, pointValuesStart[i]);
            flagProperties.SetFlagManager(this);
            // flagInfoList.Add(fruitInfoInstance);
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

            Debug.Log("Correct flag picked up!");
            return true;
        }

        Debug.Log("Wrong flag picked up! Pick up flag: " + collectedFlagSequence[totalFlags - 1]);
        return false;
    }
}
