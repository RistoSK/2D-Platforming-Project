using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : BaseController<UIGameRoot>
{ 
    [SerializeField] private GameObject _levelCompletedCanvas;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private TextMeshProUGUI _currentCoinsText;
    [SerializeField] private CoinManager _coinManager;

    private bool _bFreezeTimer;
    private float _timer;
    private AudioSource _audioSource;

    public override void InitiateController()
    {   
        ui.GameView.OnPauseClicked += PauseGame;
        ui.GameView.OnQuitClicked += QuitGame;
        _coinManager.OnCoinGained += CoinGained;

        base.InitiateController();
    }

    public override void DisableController()
    {
        base.DisableController();

        ui.GameView.OnPauseClicked -= PauseGame;
        ui.GameView.OnQuitClicked -= QuitGame;
        _coinManager.OnCoinGained -= CoinGained;
    }

    public int GetCurrentCoins()
    {
        return _coinManager.CurrentCoinAmount;
    }

    public string GetEndingTime()
    {
        return _timerText.text;
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _currentCoinsText.text = "0 / 50";
        _timer = 0f;
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

    public void WonGame()
    {
        _bFreezeTimer = true;

        if (_coinManager.AllCoinsCollected())
        {
            _levelCompletedCanvas.SetActive(true);
            return;
        }
        SceneManager.LoadScene(0);
    }

    private void PauseGame()
    {
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
}
