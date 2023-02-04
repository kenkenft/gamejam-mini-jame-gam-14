using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    PlayerMain playerMain;
    UIManager uIManager;
    FlagManager flagManager;
    ExitProperties exitProperties;

    // Start is called before the first frame update
    void Start()
    {
        playerMain = GetComponentInChildren<PlayerMain>();
        playerMain.SetUp();
        playerMain.SetIsPlaying(true);

        flagManager = GetComponentInChildren<FlagManager>();
        flagManager.SetUp();

        exitProperties = GetComponentInChildren<ExitProperties>();
        exitProperties.SetUp();
        // uIManager = GetComponentInChildren<UIManager>();
        // uIManager.SetUpUIRefs();
        // uIManager.ReturnToTitle();
    }

    public void UnlockExitZone(int exitZoneID)
    {
        exitProperties.DisableBarrier(exitZoneID);
    }

    public void AdvanceGameState()
    {
        playerMain.SetLevelState(1);
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
