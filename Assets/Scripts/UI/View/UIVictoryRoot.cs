using UnityEngine;

public class UIVictoryRoot : UIRoot
{
    [SerializeField] private UIVictoryView _victoryView;

    public UIVictoryView VictoryView => _victoryView;

    public override void ShowRoot()
    {
        base.ShowRoot();

        _victoryView.ShowView();
    }

    public override void HideRoot()
    {
        _victoryView.HideView();

        base.HideRoot();
    }
}
