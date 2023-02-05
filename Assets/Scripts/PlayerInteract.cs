using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    bool isInteracting = false;
    public float pickUpCooldown = 0.3f, lastSuccessfulPressTime = 0f, currButtonPressTime = 0f;
    FlagProperties targetFlag;

    public bool PickUp(int levelState)
    {
        if(targetFlag != null)
        {
            currButtonPressTime = Time.time;

            // if(targetFlag.GetIsPickedUp())
            if((currButtonPressTime - lastSuccessfulPressTime > pickUpCooldown))
            {
                lastSuccessfulPressTime = currButtonPressTime;
                if(levelState == 0 && !targetFlag.GetIsPickedUp())
                    targetFlag.SetIsPickedUp(true, levelState);
                else if(levelState == 1 && targetFlag.GetIsPickedUp())
                    targetFlag.SetIsPickedUp(false, levelState);
                    
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
                targetFlag = col.GetComponentInParent<FlagProperties>();
                break;
            }

            case("Exit00"):
            {
                gameObject.GetComponent<PlayerMain>().SetLevelState(1);
                col.gameObject.SetActive(false);
                break;
            }

            case("Exit01"):
            {
                gameObject.GetComponentInParent<GameManager>().TriggerEndLevel();
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
            targetFlag = null;
        }
    }
}
