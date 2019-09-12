using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootController : MonoBehaviour
{
    public enum ControllerType
    {
        Menu,
        Victory,
        Unfinished,
        Game,
        Pause
    }

    [SerializeField] private MenuController _menuController;
    [SerializeField] private VictoryController _victoryController;
    [SerializeField] private UnfinishedController _unfinishedController;
    [SerializeField] private GameController _gameController;
    [SerializeField] private PauseController _pauseController;

    private void Start()
    {
        _menuController.root = this;
        _victoryController.root = this;
        _unfinishedController.root = this;
        _gameController.root = this;
        _pauseController.root = this;

        ChangeController(ControllerType.Menu);
    }

    public void ChangeController(ControllerType type)
    {
        DisableControllers();

        switch (type)
        {
            case ControllerType.Menu:
                _menuController.InitiateController();
                break;
            case ControllerType.Game:
                _gameController.InitiateController();
                break;
            case ControllerType.Pause:
                _pauseController.InitiateController();
                break;
            case ControllerType.Victory:
                _victoryController.InitiateController();
                break;
            case ControllerType.Unfinished:
                _unfinishedController.InitiateController();
                break;             
        }
    }

    public void DisableControllers()
    {
        _menuController.DisableController();
        _victoryController.DisableController();
        _unfinishedController.DisableController();
        _gameController.DisableController();
        _pauseController.DisableController();
    }
}
