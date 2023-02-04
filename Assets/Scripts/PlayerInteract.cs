using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public bool isPicking = false;
    public float pickUpCooldown = 0.3f, lastSuccessfulPressTime = 0f, currButtonPressTime = 0f;


    public bool Harvest()
    {
        // if(targetCrop != null)
        // {
        //     // currButtonPressTime = Time.time;
        //     // if((currButtonPressTime - lastSuccessfulPressTime > harvestCooldown) 
        //     //     && targetCrop.CheckHarvestable())
        //     if(targetCrop.CheckHarvestable())
        //     {
        //         // lastSuccessfulPressTime = currButtonPressTime;
        //         harvestProgress = targetCrop.HarvestFruit(harvestPower);
        //         if(harvestProgress >= 100)
        //             return true;
        //     }
        // }
        // else
        //     Debug.Log("Can't use harvest action yet!");

        return false;
        
    }

    // public int CheckHarvestedFruitType()
    // {
    //     return targetCrop.GetCurrentFruitType();
    // }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Crop"))
        {
            isPicking = true;
            // targetCrop = col.GetComponentInParent<CropProperties>();
            // Debug.Log("Entered crop harvest radius");
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Crop")
        {
            isPicking = false;
            // targetCrop = null;
            // Debug.Log("Exited crop harvest radius");
        }
    }
}
