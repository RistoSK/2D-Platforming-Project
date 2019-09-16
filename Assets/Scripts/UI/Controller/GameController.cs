using TMPro;
using UnityEngine;

public class GameController : BaseController<UIGameRoot>
{ 
    [SerializeField] private CoinManager _coinManager;
    [SerializeField] private GameAudio _gameAudio;
    [SerializeField] private PlayersTargetGoal _playersTargetGoal;

    public override void InitiateController()
    {   
        ui.GameView.OnPauseClicked += PauseGame;
        ui.GameView.OnQuitClicked += QuitGame;
        _playersTargetGoal.OnLevelFinished += LevelFinished;

        base.InitiateController();
    }

    public override void DisableController()
    {
        base.DisableController();

        ui.GameView.OnPauseClicked -= PauseGame;
        ui.GameView.OnQuitClicked -= QuitGame;
        _playersTargetGoal.OnLevelFinished -= LevelFinished;
    }

    private void PauseGame()
    {
        _gameAudio.GamePaused();
        root.ChangeController(RootController.ControllerType.Pause);
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void LevelFinished()
    {
        if (_coinManager.AllCoinsCollected())
        {
            root.ChangeController(RootController.ControllerType.Victory);
            return;
        }

        _coinManager.SetUnfinishedCoinsText();
        root.ChangeController(RootController.ControllerType.Unfinished);
    }

}
