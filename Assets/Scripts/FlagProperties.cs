using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagProperties : MonoBehaviour
{
    bool[] isPickedUp = {false, false};
    int flagID, pointValue;
    GameObject flagMain;
    Vector3 mask = new Vector3(0.27f,0f,0f);

    public void SetUp(int assignedID, int initialValue)
    {
        isPickedUp[0] = false;
        isPickedUp[1] = false;
        flagID = assignedID;
        pointValue = initialValue;
        Transform[] allTransforms = GetComponentsInChildren<Transform>();
        foreach(Transform transform in allTransforms)
        {
            if(transform.name == "FlagMain")
            {
                flagMain = transform.gameObject;
                break;
            }
        }
    }

    public void RaiseLowerFlag(bool isRaising)
    {
        if(isRaising)
            mask[1] = -0.07f;
        else
            mask[1] = -0.57f;
            
        flagMain.transform.position = mask;
    }

    public void SetIsPickedUp(int levelState, bool state)
    {
        isPickedUp[levelState] = state;
    }

}
