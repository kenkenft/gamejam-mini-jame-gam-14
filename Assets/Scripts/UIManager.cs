using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        uIEndLevel = GetComponentInChildren<UIEndLevel>();
        if(uIEndLevel != null)
        {
            uIEndLevel.SetUp();
            uIEndLevel.ToggleEndLevelCanvas(false);
        }
        playerOverlay = GetComponentInChildren<PlayerOverlay>();
        playerOverlay.SetUp();
        // uIEndgame = GetComponentInChildren<UIEndgame>();
        // uIEndgame.SetUp();
        // uITitle = GetComponentInChildren<UITitle>();
        // uITitle.SetUp();
        audioManager = GetComponentInParent<AudioManager>();

    }

    public void TriggerEndLevelUI()
    {
        // playerOverlay.TogglePlayerOverlayCanvas(false);
        uIEndLevel.ToggleEndLevelCanvas(true);

    }

    public void UpdatePlayerOverlay()
    {
        playerOverlay.UpdatePlayerOverlay(gameDataProperties.GetLevelScore());
    }

    public void TriggerEndgameUI()
    {
        // playerMain.SetIsPlaying(false);
        playerOverlay.TogglePlayerOverlayCanvas(false);
        uIEndgame.ToggleEndgameCanvas(true);
        uIEndgame.SetPlayerScoreText(gameDataProperties.GetLevelScore());
        uIEndgame.SetTotalTime(playerOverlay.GetTotalTime());
        audioManager.Play("Endgame");
    }

    public void SetUpGameUI(int startTime)
    {
        uITitle.DisableTitleCanvases();
        uITitle.ToggleButtonEnabled(false);
        uIEndgame.ToggleEndgameCanvas(false);
        uIEndgame.SetPlayerScoreText(0);
        playerOverlay.TogglePlayerOverlayCanvas(true);
        playerOverlay.ResetOverlay();
        playerOverlay.StartTimer(startTime);
        audioManager.Play("ButtonClick");

    }

    public void ReturnToTitle()
    {
        playerOverlay.TogglePlayerOverlayCanvas(false);
        uIEndgame.ToggleEndgameCanvas(false);
        uITitle.SwitchTitleInstructionScreens();
        uITitle.ToggleButtonEnabled(true);
        audioManager.Play("ButtonClick");
    }

    public void SwitchTitleScreens()
    {
        uITitle.SwitchTitleInstructionScreens();
        audioManager.Play("ButtonClick");
    }

}
