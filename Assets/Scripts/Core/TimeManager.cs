using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _victoryTimerText;

    private TextMeshProUGUI _timerText;
    private float _timer;

    private void Start()
    {
        _timerText = GetComponent<TextMeshProUGUI>();
        _timer = 0f;
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        int minutes = ((int)_timer / 60);
        int seconds = ((int)_timer % 60);

        _timerText.text = string.Format("{0:00}:{1:00}", (minutes), (seconds % 60));
    }

    public void SetVictoryTimerText()
    {
        _victoryTimerText.text = _timerText.text;
    }

}
