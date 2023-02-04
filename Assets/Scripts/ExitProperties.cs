using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitProperties : MonoBehaviour
{
    public GameObject[] zoneBarriers;
    public Collider2D[] zoneTriggers;

    public void SetUp()
    {
        zoneBarriers[0].SetActive(true);
        zoneBarriers[1].SetActive(true);
    }

    public void DisableBarrier(int barrierID)
    {
        zoneBarriers[barrierID].SetActive(false);
    }


}
