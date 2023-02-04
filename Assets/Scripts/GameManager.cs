using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    PlayerMain playerMain;
    UIManager uIManager;
    FlagManager flagManager;

    // Start is called before the first frame update
    void Start()
    {
        playerMain = GetComponentInChildren<PlayerMain>();
        playerMain.SetUp();
        playerMain.SetIsPlaying(true);

        flagManager = GetComponentInChildren<FlagManager>();
        flagManager.SetUp();
        // uIManager = GetComponentInChildren<UIManager>();
        // uIManager.SetUpUIRefs();
        // uIManager.ReturnToTitle();
    }

    public void SetUpGame()
    {
        playerMain.SetIsPlaying(true);
        playerMain.SetPlayerStartPos();
        uIManager.SetUpGameUI(200);
    }

    public void TriggerEndgame()
    {
        StopAllCoroutines();
        playerMain.SetIsPlaying(false);
        uIManager.TriggerEndgameUI();
    }

}
