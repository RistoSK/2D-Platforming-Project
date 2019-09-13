using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryController : BaseController<UIVictoryRoot>
{
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private GameController _gameController;

    public override void InitiateController()
    {
        ui.VictoryView.OnReplayClicked += ReplayGame;
        ui.VictoryView.OnQuitClicked += QuitGame;

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
