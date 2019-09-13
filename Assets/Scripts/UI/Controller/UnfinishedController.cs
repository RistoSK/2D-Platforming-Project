﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnfinishedController : BaseController<UIUnfinishedRoot>
{
    [SerializeField] private TextMeshProUGUI _coinsText;
    [SerializeField] private GameController _gameController;

    public override void InitiateController()
    {
        // _gameData = new GameData();

        ui.UnfinishedView.OnReplayClicked += ReplayGame;
        ui.UnfinishedView.OnQuitClicked += QuitGame;

        //ui.GameView.UpdateTime(0);

        base.InitiateController();
    }

    public override void DisableController()
    {
        base.DisableController();

        ui.UnfinishedView.OnReplayClicked -= ReplayGame;
        ui.UnfinishedView.OnQuitClicked -= QuitGame;
    }

    private void OnEnable()
    {
        _coinsText.text = _gameController.GetCurrentCoins() + " / 50";
    }

    private void ReplayGame()
    {
        SceneManager.LoadScene(0);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
