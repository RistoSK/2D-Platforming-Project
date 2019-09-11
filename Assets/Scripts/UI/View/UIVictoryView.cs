using UnityEngine.Events;

public class UIVictoryView : UIView
{
    public UnityAction OnReplayClicked;
    public UnityAction OnQuitClicked;

    public void ReplayClicked()
    {
        OnReplayClicked?.Invoke();
    }

    public void QuitClicked()
    {
        OnQuitClicked?.Invoke();
    }
}