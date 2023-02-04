using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    PlayerOverlay playerOverlay;
    UIEndgame uIEndgame;
    UITitle uITitle;
    AudioManager audioManager;  


    
    public void SetUpUIRefs()
    {
        
        playerOverlay = GetComponentInChildren<PlayerOverlay>();
        playerOverlay.SetUp();
        uIEndgame = GetComponentInChildren<UIEndgame>();
        uIEndgame.SetUp();
        uITitle = GetComponentInChildren<UITitle>();
        uITitle.SetUp();
        audioManager = GetComponentInParent<AudioManager>();

    }


    public void TriggerEndgameUI()
    {
        // playerMain.SetIsPlaying(false);
        playerOverlay.TogglePlayerOverlayCanvas(false);
        uIEndgame.ToggleEndgameCanvas(true);
        uIEndgame.SetPlayerScoreText(playerOverlay.GetFinalScore());
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
