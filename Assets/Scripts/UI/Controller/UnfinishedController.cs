using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnfinishedController : BaseController<UIUnfinishedRoot>
{
    //private GameData _gameData;

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

    private void Update()
    {
        //_gameData.gameTime += Time.deltaTime;
        //ui.GameView.UpdateTime(_gameData.gameTime);
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
