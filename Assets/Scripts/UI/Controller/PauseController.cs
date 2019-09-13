using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : BaseController<UIPauseRoot>
{
    public override void InitiateController()
    {
        ui.PauseView.OnResumeClicked += ResumeGame;
        ui.PauseView.OnRestartClicked += RestartGame;
        ui.PauseView.OnQuitClicked += QuitGame;

        base.InitiateController();
    }

    public override void DisableController()
    {
        base.DisableController();

        ui.PauseView.OnResumeClicked -= ResumeGame;
        ui.PauseView.OnRestartClicked -= RestartGame;
        ui.PauseView.OnQuitClicked -= QuitGame;
    }

    private void ResumeGame()
    {
        root.ChangeController(RootController.ControllerType.Game);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
