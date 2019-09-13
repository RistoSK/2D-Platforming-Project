using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _levelCompletedCanvas;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private CoinManager _coinManager;

    private bool _bFreezeTimer;
    private float _timer;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();

        _timer = 0f;
    }

    private void Update()
    {
        if (!_bFreezeTimer)
        {
            _timer += Time.deltaTime;

            string minutes = ((int)_timer / 60).ToString();
            string seconds = (_timer % 60).ToString("f0");
            _timerText.text = minutes + " : " + seconds;
        }
    }

    public void WonGame()
    {
        _bFreezeTimer = true;

        if(_coinManager.AllCoinsCollected())
        {
            _levelCompletedCanvas.SetActive(true);
            return;
        }
        SceneManager.LoadScene(0);
    }
}
