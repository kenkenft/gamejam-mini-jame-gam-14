using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    bool isInteracting = false;
    public float pickUpCooldown = 0.3f, lastSuccessfulPressTime = 0f, currButtonPressTime = 0f;
    FlagProperties targetFlag;

    public bool PickUp()
    {
        if(targetFlag != null)
        {
            currButtonPressTime = Time.time;

            // if(targetFlag.GetIsPickedUp())
            if((currButtonPressTime - lastSuccessfulPressTime > pickUpCooldown) && !targetFlag.GetIsPickedUp())
            {
                lastSuccessfulPressTime = currButtonPressTime;
                targetFlag.SetIsPickedUp(true);
                targetFlag.RaiseFlagSprite(true);
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
                Debug.Log("Exit00 entered!");
                break;
            }

            case("Exit01"):
            {
                Debug.Log("Exit01 entered!");
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
