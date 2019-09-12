using UnityEngine.Events;

public class UIPauseView : UIView
{
    public UnityAction OnResumeClicked;
    public UnityAction OnRestartClicked;
    public UnityAction OnQuitClicked;

    public void ResumeClicked()
    {
        OnResumeClicked?.Invoke();
    }

    public void RestartClicked()
    {
        OnRestartClicked?.Invoke();
    }

    public void QuitClicked()
    {
        OnQuitClicked?.Invoke();
    }
}