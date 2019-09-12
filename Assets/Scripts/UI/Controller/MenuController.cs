using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : BaseController<UIMenuRoot>
{
    public override void InitiateController()
    {
        ui.MenuView.OnPlayClicked += StartGame;
        ui.MenuView.OnQuitClicked += QuitGame;

        base.InitiateController();
    }

    public override void DisableController()
    {
        base.DisableController();

        ui.MenuView.OnQuitClicked -= QuitGame;
        ui.MenuView.OnPlayClicked -= StartGame;
    }

    private void StartGame()
    {
        root.ChangeController(RootController.ControllerType.Game);
        //Start Game
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
