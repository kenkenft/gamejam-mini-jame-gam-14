using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    PlayerMain playerMain;
    UIManager uIManager;
    FlagManager flagManager;
    ExitProperties exitProperties;
    Timer timer;

    public GameDataProperties gameDataProperties;

    // Start is called before the first frame update
    void Start()
    {
        playerMain = GetComponentInChildren<PlayerMain>();
        playerMain.SetUp();
        playerMain.SetIsPlaying(true);

        timer = gameObject.GetComponent<Timer>();
        StartCoroutine(timer.StartTimer());

        flagManager = GetComponentInChildren<FlagManager>();
        flagManager.SetUp(gameDataProperties);

        exitProperties = GetComponentInChildren<ExitProperties>();
        exitProperties.SetUp();

        uIManager = GetComponentInChildren<UIManager>();
        uIManager.SetUpUIRefs(gameDataProperties);
        // uIManager.ReturnToTitle();
    }

    public void UnlockExitZone(int exitZoneID)
    {
        exitProperties.DisableBarrier(exitZoneID);
        // Debug.Log("Unlocked ExitZone: " + exitZoneID);
    }

    public void AdvanceGameState()
    {
        playerMain.SetLevelState(1);
    }

    public void UpdatePlayerOverlay()
    {
        uIManager.UpdatePlayerOverlay();
    }

    public void SetUpGame()
    {
        playerMain.SetIsPlaying(true);
        playerMain.SetPlayerStartPos();
        uIManager.SetUpGameUI(200);
    }

    public void TriggerEndLevel()
    {
        Debug.Log("EndLevel Triggered!");
        gameDataProperties.UpdateGameData(timer.GetTotalTime(), "levelTime");
        gameDataProperties.UpdateGameData(0, "totalScore");
        gameDataProperties.UpdateGameData(0, "totalMistakes");
        gameDataProperties.UpdateGameData(0, "totalTime");
        

        uIManager.TriggerEndLevelUI();
    }


    public void TriggerEndgame()
    {
        StopAllCoroutines();
        playerMain.SetIsPlaying(false);
        uIManager.TriggerEndgameUI();
    }

}
