using UnityEngine;

public class UIPauseRoot : UIRoot
{
    [SerializeField] private UIPauseView _pauseView;

    public UIPauseView PauseView => _pauseView;

    public override void ShowRoot()
    {
        base.ShowRoot();

        _pauseView.ShowView();
    }

    public override void HideRoot()
    {
        _pauseView.HideView();

        base.HideRoot();
    }
}
