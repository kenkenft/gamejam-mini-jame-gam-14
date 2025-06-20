using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    PlayerOverlay playerOverlay;
    UIEndgame uIEndgame;
    UITitle uITitle;
    UIEndLevel uIEndLevel;
    AudioManager audioManager;  
    GameDataProperties gameDataProperties;


    
    public void SetUpUIRefs(GameDataProperties instance)
    {
        
        gameDataProperties = instance;
        gameDataProperties.UpdateGameData(SceneManager.GetActiveScene().buildIndex, "targetStageID");
        uIEndLevel = GetComponentInChildren<UIEndLevel>();
        if(uIEndLevel != null)
        {
            uIEndLevel.SetUp();
            uIEndLevel.ToggleEndLevelCanvas(false);
        }
        playerOverlay = GetComponentInChildren<PlayerOverlay>();
        if(playerOverlay != null)
        {
            playerOverlay.SetUp();
        }
        // uIEndgame = GetComponentInChildren<UIEndgame>();
        // uIEndgame.SetUp();

        uITitle = GetComponentInChildren<UITitle>();
        if(uITitle != null)
           uITitle.SetUp();
        
        audioManager = GetComponentInParent<AudioManager>();

    }

    public void TriggerEndLevelUI()
    {
        playerOverlay.TogglePlayerOverlayCanvas(false);
        uIEndLevel.ToggleEndLevelCanvas(true);
        uIEndLevel.SetLevelScoreText(gameDataProperties.GetGameData("levelScore"));
        uIEndLevel.SetTotalScoreText(gameDataProperties.GetGameData("totalScore"));
        uIEndLevel.SetTotalTime(gameDataProperties.GetGameData("levelTime"));
        uIEndLevel.SetLevelMistakesText(gameDataProperties.GetGameData("levelMistakes"));
        audioManager.Play("Endgame");
    }

    public void UpdatePlayerOverlay()
    {
        playerOverlay.UpdatePlayerOverlay(gameDataProperties.GetGameData("levelScore"));
    }

    public void TriggerEndgameUI()
    {
        // playerMain.SetIsPlaying(false);
        playerOverlay.TogglePlayerOverlayCanvas(false);
        uIEndgame.ToggleEndgameCanvas(true);
        uIEndgame.SetPlayerScoreText(gameDataProperties.GetGameData("totalScore"));
        uIEndgame.SetTotalTime(gameDataProperties.GetGameData("totalTime"));
        // uIEndgame.SetTotalMistakes(gameDataProperties.GetGameData("totalMistakes"));

        audioManager.Play("Endgame");
    }

    public void SetUpGameUI()
    {
        uITitle.DisableTitleCanvases();
        uITitle.ToggleButtonEnabled(false);
        uIEndgame.ToggleEndgameCanvas(false);
        uIEndgame.SetPlayerScoreText(0);
        playerOverlay.TogglePlayerOverlayCanvas(true);
        playerOverlay.ResetOverlay();
        // playerOverlay.StartTimer(startTime);
        audioManager.Play("ButtonClick");

    }

    public void ReturnToTitle()
    {
        if(uITitle != null)
        {
            // playerOverlay.TogglePlayerOverlayCanvas(false);
            // uIEndgame.ToggleEndgameCanvas(false);
            uITitle.SwitchTitleInstructionScreens();
            uITitle.ToggleButtonEnabled(true);
            audioManager.Play("ButtonClick");
        }
    }

    public void SwitchTitleScreens()
    {
        uITitle.SwitchTitleInstructionScreens();
        audioManager.Play("ButtonClick");
    }

    public void LoadLevel(int targetID, bool isFinalLevel)
    {
        audioManager.Play("ButtonClick");
        gameDataProperties.UpdateGameData(targetID, "targetStageID");
        if(!isFinalLevel)
            SceneManager.LoadScene(gameDataProperties.GetGameData("targetStageID"));
        else
            SceneManager.LoadScene(0);
    }

}
