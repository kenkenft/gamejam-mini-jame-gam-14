using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    bool isInteracting = false;
    public float pickUpCooldown = 0.3f, lastSuccessfulPressTime = 0f, currButtonPressTime = 0f;
    // FlagProperties targetFlag;
    GameObject targetFlag;

    public bool PickUp(int levelState)
    {
        if(targetFlag != null)
        {
            currButtonPressTime = Time.time;

            // if(targetFlag.GetIsPickedUp())
            if((currButtonPressTime - lastSuccessfulPressTime > pickUpCooldown))
            {
                lastSuccessfulPressTime = currButtonPressTime;
                // if(levelState == 0 && !targetFlag.GetComponentInParent<FlagProperties>().GetIsPickedUp())
                //     targetFlag.GetComponentInParent<FlagProperties>().SetIsPickedUp(true, levelState);
                // else if(levelState == 1 && targetFlag.GetComponentInParent<FlagProperties>().GetIsPickedUp())
                //     targetFlag.GetComponentInParent<FlagProperties>().SetIsPickedUp(false, levelState);
                
                // targetFlag.gameObject.SendMessage("CheckWhichActionToDo", levelState);
                targetFlag.SendMessage("CheckWhichActionToDo", levelState);
                
                return true;
            }
        }
        else
            Debug.Log("Not near a flag!");

        return false;
        
    }

    public bool GetIsInteracting()
    {
        return isInteracting;
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        switch(col.tag)
        {
            case("Flag"):
            {
                isInteracting = true;
                // Debug.Log("isInteracting: " + isInteracting);
                // targetFlag = col.GetComponentInParent<FlagProperties>();
                targetFlag = col.gameObject;
                break;
            }

            case("Exit00"):
            {
                gameObject.GetComponent<PlayerMain>().SetLevelState(1);
                // col.gameObject.SetActive(false);
                // gameObject.GetComponentInParent<GameManager>().DisableGroundStateZero();
                gameObject.SendMessageUpwards("DisableGroundStateZero");
                break;
            }

            case("Exit01"):
            {
                // gameObject.GetComponentInParent<GameManager>().TriggerEndLevel();
                gameObject.SendMessageUpwards("TriggerEndLevel");
                break;
            }

            default:
                break;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Flag")
        {
            isInteracting = false;
            // Debug.Log("isInteracting: " + isInteracting);
            targetFlag = null;
        }
    }
}
