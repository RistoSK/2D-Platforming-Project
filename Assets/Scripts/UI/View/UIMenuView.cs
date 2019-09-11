using UnityEngine.Events;

public class UIMenuView : UIView
{
    public UnityAction OnPlayClicked;
    public UnityAction OnQuitClicked;

    public void PlayClicked()
    {
        OnPlayClicked?.Invoke();
    }

    public void QuitClicked()
    {
        OnQuitClicked?.Invoke();
    }
}