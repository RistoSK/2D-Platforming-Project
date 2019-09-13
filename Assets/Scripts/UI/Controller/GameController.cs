using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : BaseController<UIGameRoot>
{ 
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private TextMeshProUGUI _currentCoinsText;
    [SerializeField] private CoinManager _coinManager;
    [SerializeField] private PlayersTargetGoal _playersTargetGoal;

    private bool _bFreezeTimer;
    private float _timer;
    private AudioSource _audioSource;
    private float _playbackTime;

    public override void InitiateController()
    {   
        ui.GameView.OnPauseClicked += PauseGame;
        ui.GameView.OnQuitClicked += QuitGame;
        _coinManager.OnCoinGained += CoinGained;
        _playersTargetGoal.OnLevelFinished += LevelFinished;

        base.InitiateController();
    }

    public override void DisableController()
    {
        base.DisableController();

        ui.GameView.OnPauseClicked -= PauseGame;
        ui.GameView.OnQuitClicked -= QuitGame;
        _coinManager.OnCoinGained -= CoinGained;
        _playersTargetGoal.OnLevelFinished -= LevelFinished;
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _currentCoinsText.text = "0 / 50";
        _timer = 0f;

        _audioSource.Play();
    }

    private void OnEnable()
    {
        if (_audioSource != null)
        {
            _audioSource.time = _playbackTime;
            _audioSource.Play();
        }
    }

    private void Update()
    {
        if (!_bFreezeTimer)
        {
            _timer += Time.deltaTime;

            int minutes = ((int)_timer / 60);
            int seconds = ((int)_timer % 60);

            _timerText.text = string.Format("{0:00}:{1:00}", (minutes), (seconds % 60));
        }
    }

    public int GetCurrentCoins()
    {
        return _coinManager.CurrentCoinAmount;
    }

    public string GetEndingTime()
    {
        return _timerText.text;
    } 

    private void PauseGame()
    {
        _playbackTime = _audioSource.time;
        root.ChangeController(RootController.ControllerType.Pause);
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void CoinGained()
    {
        _currentCoinsText.text = _coinManager.CurrentCoinAmount + " / 50";
    }

    private void LevelFinished()
    {
        if (_coinManager.AllCoinsCollected())
        {
            root.ChangeController(RootController.ControllerType.Victory);
            return;
        }

        root.ChangeController(RootController.ControllerType.Unfinished);
    }

}
