using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    int totalTime = 0;
    WaitForSecondsRealtime timerDelay = new WaitForSecondsRealtime(1.0f);


    public IEnumerator StartTimer()
    {
        while(true)
        {
            totalTime++;
            yield return timerDelay;
        }
    }


    public int GetTotalTime()
    {
        Debug.Log("GetTotalTime called! Returning: " + totalTime);
        return totalTime;
    }

    public void ResetTotalTime()
    {
        Debug.Log("ResetTotalTime called");
        totalTime = 0;
    }
}
