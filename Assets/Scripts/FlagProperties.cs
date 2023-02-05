using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagProperties : MonoBehaviour
{
    // bool[] isPickedUp = {false, false};
    [SerializeField] bool isPickedUp = false;
    public int flagID, pointValue;
    GameObject flagMain;
    public FlagManager flagManager;
    Vector3 flagPosMask = new Vector3(0.27f,0f,0f);

    public void SetUp(int assignedID, int initialValue)
    {
        // isPickedUp[0] = false;
        // isPickedUp[1] = false;
        isPickedUp = false;
        flagID = assignedID;
        pointValue = initialValue;
        Transform[] allTransforms = GetComponentsInChildren<Transform>();
        foreach(Transform transform in allTransforms)
        {
            if(transform.name == "FlagMain")
            {
                flagMain = transform.gameObject;
                // SetIsPickedUp(false);
                break;
            }
        }
    }


    // public void SetIsPickedUp(int levelState, bool state)
    // {
    //     isPickedUp[levelState] = state;
    // }
    public void SetIsPickedUp(bool isRaised, int levelState)
    {
        bool isCorrect = false;
        if(!isPickedUp && levelState == 0)
        {
            // Debug.Log("isPickedUp && levelState == 0");
            flagManager.RecordFlagOrder(flagID);
            RaiseFlagSprite(true);
            flagManager.ModifyScore(pointValue);

            isPickedUp = isRaised;

        }
        else if((isPickedUp && levelState == 1))
        {
            // Debug.Log("!isPickedUp && levelState == 1");
            isCorrect = flagManager.CheckReverseOrder(flagID);
            if(isCorrect)
            {    
                RaiseFlagSprite(false);
                isPickedUp = isRaised;
            }
            else
            {
                flagManager.ModifyScore(-1 * pointValue);
            }
        }
    }

    public void RaiseFlagSprite(bool isRaising)
    {
        if(isRaising)
            flagPosMask[1] = -0.07f;
        else
            flagPosMask[1] = -0.57f;
            
        flagMain.transform.localPosition = flagPosMask;
    }

    public bool GetIsPickedUp()
    {
        return isPickedUp;
    }

    public void SetFlagManager(FlagManager instance)
    {
        flagManager = instance;
    }

}
