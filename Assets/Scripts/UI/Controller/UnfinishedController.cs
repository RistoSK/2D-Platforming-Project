using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnfinishedController : BaseController<UIUnfinishedRoot>
{
    public override void InitiateController()
    {
        ui.UnfinishedView.OnReplayClicked += ReplayGame;
        ui.UnfinishedView.OnQuitClicked += QuitGame;

        base.InitiateController();
    }

    public override void DisableController()
    {
        base.DisableController();

        ui.UnfinishedView.OnReplayClicked -= ReplayGame;
        ui.UnfinishedView.OnQuitClicked -= QuitGame;
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
