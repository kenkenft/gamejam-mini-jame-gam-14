using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILoadLevel : MonoBehaviour
{
    public int targetScene;

    public void GoToThisScene()
    {
        GetComponentInParent<UIManager>().LoadLevel(targetScene);
    }
}
