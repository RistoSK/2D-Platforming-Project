using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameRoot : UIRoot
{
    [SerializeField] private UIGameView _gameView;

    public UIGameView GameView => _gameView;

    public override void ShowRoot()
    {
        base.ShowRoot();

        _gameView.ShowView();
    }

    public override void HideRoot()
    {
        _gameView.HideView();

        base.HideRoot();
    }
}
