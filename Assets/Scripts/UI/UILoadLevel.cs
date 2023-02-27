using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILoadLevel : MonoBehaviour
{
    public int targetScene;
    public bool isFinalLevel = false;

    public void GoToThisScene()
    {
        GetComponentInParent<UIManager>().LoadLevel(targetScene, isFinalLevel);
    }
}
