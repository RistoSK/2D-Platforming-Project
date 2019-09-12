using UnityEngine.Events;

public class UIGameView : UIView
{
    public UnityAction OnPauseClicked;
    public UnityAction OnQuitClicked;

    public void PauseClicked()
    {
        OnPauseClicked?.Invoke();
    }

    public void QuitClicked()
    {
        OnQuitClicked?.Invoke();
    }
}
