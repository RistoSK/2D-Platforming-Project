using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIUnfinishedRoot : UIRoot
{
    [SerializeField] private UIUnfinishedView _unfinishedView;

    public UIUnfinishedView UnfinishedView => _unfinishedView;

    public override void ShowRoot()
    {
        base.ShowRoot();

        _unfinishedView.ShowView();
    }

    public override void HideRoot()
    {
        _unfinishedView.HideView();

        base.HideRoot();
    }
}
