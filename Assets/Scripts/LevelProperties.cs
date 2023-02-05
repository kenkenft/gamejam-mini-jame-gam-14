using System.Collections.Generic;
using System.Collections;
using UnityEngine;

// [System.Serializable]
public class LevelProperties
{
    List<int[]> flagsPointsList = new List<int[]>{
                                                new int[] {30, 80, 60},
                                                new int[] {40, 60, 80, 40},
                                                new int[] {80, 60, 50, 20}
                                            };

    public int[] GetLevelFlagsPoints(int levelID)
    {
        return flagsPointsList[levelID];
    }

}
