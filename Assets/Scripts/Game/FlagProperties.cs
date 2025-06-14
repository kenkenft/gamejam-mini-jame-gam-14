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
    public GameObject[] flagNumberSpritePos;

    public Sprite[] flagNumberSprites;
    Vector3 flagPosMask = new Vector3(0.27f,0f,0f);
    AudioManager audioManager;

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
        UpdateFlagPointTextSprites();
        audioManager = GetComponentInParent<AudioManager>();
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
            flagManager.ModifyScore(pointValue * 10);

            isPickedUp = isRaised;
            audioManager.Play("Interact");

        }
        else if((isPickedUp && levelState == 1))
        {
            // Debug.Log("!isPickedUp && levelState == 1");
            isCorrect = flagManager.CheckReverseOrder(flagID);
            if(isCorrect)
            {    
                RaiseFlagSprite(false);
                isPickedUp = isRaised;
                audioManager.Play("Interact");
            }
            else
            {
                flagManager.ModifyScore(pointValue * -10);
                audioManager.Play("Wrong");
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

    public void UpdateFlagPointTextSprites()
    {
        int tempInt = 0;
        tempInt = pointValue % 10;
        flagNumberSpritePos[1].GetComponent<SpriteRenderer>().sprite = flagNumberSprites[tempInt];

        tempInt = pointValue / 10;
        flagNumberSpritePos[0].GetComponent<SpriteRenderer>().sprite = flagNumberSprites[tempInt];
    }

    public void CheckWhichActionToDo(int levelState)
    {
        // Debug.Log("FlagProperties.CheckWhichActionToDo called. levelState: " + levelState);
        if(levelState == 0 && !GetIsPickedUp())
            SetIsPickedUp(true, levelState);
        else if(levelState == 1 && GetIsPickedUp())
            SetIsPickedUp(false, levelState);
    }

}
