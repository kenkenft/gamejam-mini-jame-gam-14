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
                {
                    //  Debug.Log("levelState == 0 && !targetFlag.GetIsPickedUp()");
                    targetFlag.SetIsPickedUp(true, levelState);
                    // targetFlag.RaiseFlagSprite(true);
                }
                else if(levelState == 1 && targetFlag.GetIsPickedUp())
                {
                    //  Debug.Log("levelState == 1 && targetFlag.GetIsPickedUp()");
                    targetFlag.SetIsPickedUp(false, levelState);
                    // targetFlag.RaiseFlagSprite(false);
                }
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
                // Debug.Log("Entered crop harvest radius");
                break;
            }

            case("Exit00"):
            {
                // Debug.Log("Exit00 entered!");
                gameObject.GetComponent<PlayerMain>().SetLevelState(1);
                col.gameObject.SetActive(false);
                break;
            }

            case("Exit01"):
            {
                // Debug.Log("Exit01 entered!");
                gameObject.GetComponentInParent<GameManager>().TriggerEndLevel();
                break;
            }

            default:
                break;
        }
        // if(col.gameObject.CompareTag("Flag"))
        // {
        //     isInteracting = true;
        //     targetFlag = col.GetComponentInParent<FlagProperties>();
        //     // Debug.Log("Entered crop harvest radius");
        // }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Flag")
        {
            isInteracting = false;
            targetFlag = null;
            // Debug.Log("Exited crop harvest radius");
        }
    }
}
