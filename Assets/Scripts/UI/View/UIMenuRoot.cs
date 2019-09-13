using UnityEngine;

public class UIMenuRoot : UIRoot
{
    [SerializeField] private UIMenuView _menuView;

    public UIMenuView MenuView => _menuView;

    public override void ShowRoot()
    {
        base.ShowRoot();

        _menuView.ShowView();
    }

    public override void HideRoot()
    {
        _menuView.HideView();

        base.HideRoot();
    }
}
