using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryController : BaseController<UIVictoryRoot>
{
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private GameController _gameController;

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

    private void OnEnable()
    {
        _timeText.text = _gameController.GetEndingTime();
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
