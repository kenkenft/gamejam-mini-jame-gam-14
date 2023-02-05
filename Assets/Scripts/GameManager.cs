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
    public GameObject groundStateZero;

    public GameDataProperties gameDataProperties;

    // Start is called before the first frame update
    void Start()
    {
        playerMain = GetComponentInChildren<PlayerMain>();
        if(playerMain != null)
        {
            playerMain.SetUp();
            playerMain.SetIsPlaying(true);
        }

        timer = gameObject.GetComponent<Timer>();
        if(timer != null)
            StartCoroutine(timer.StartTimer());


        exitProperties = GetComponentInChildren<ExitProperties>();
        if(exitProperties != null)
            exitProperties.SetUp();

        uIManager = GetComponentInChildren<UIManager>();
        if(uIManager != null)
            uIManager.SetUpUIRefs(gameDataProperties);
        

        flagManager = GetComponentInChildren<FlagManager>();
        if(flagManager != null)
            flagManager.SetUp(gameDataProperties);
        
        uIManager.ReturnToTitle();
    }

    public void UnlockExitZone(int exitZoneID)
    {
        exitProperties.DisableBarrier(exitZoneID);
        // Debug.Log("Unlocked ExitZone: " + exitZoneID);
    }

    public void DisableGroundStateZero()
    {
        if(groundStateZero != null)
            groundStateZero.SetActive(false);
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
        // Debug.Log("EndLevel Triggered!");
        StopAllCoroutines();
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
