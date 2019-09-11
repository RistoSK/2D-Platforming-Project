using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryController : BaseController<UIVictoryRoot>
{
    //private GameData _gameData;

    public override void InitiateController()
    {
       // _gameData = new GameData();

        ui.VictoryView.OnReplayClicked += ReplayGame;
        ui.VictoryView.OnQuitClicked += QuitGame;

        //ui.GameView.UpdateTime(0);

        base.InitiateController();
    }

    public override void DisableController()
    {
        base.DisableController();

        ui.VictoryView.OnReplayClicked -= ReplayGame;
        ui.VictoryView.OnQuitClicked -= QuitGame;
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
