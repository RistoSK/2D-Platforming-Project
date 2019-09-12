using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
        //gameScore = Mathf.CeilToInt(_gameData.gameTime * Random.Range(0.0f, 10.0f));

        // DataStorage.Instance.SaveData(Keys.GAME_DATA_KEY, _gameData);

        //root.ChangeController(RootController.ControllerType.GameOver);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
