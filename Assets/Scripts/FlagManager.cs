using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagManager : MonoBehaviour
{
    public GameObject flagPrefab;
    public Transform[] flagsPositions;
    FlagProperties flagProperties;
    [SerializeField] List<int> collectedFlagSequence = new List<int>{};
    int totalFlags = 0;
    int[] pointValuesStart = {100, 200, 300, 400, 500, 600, 700};

    public void SetUp()
    {
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
            Debug.Log("All flags have been set!");
    }
}
