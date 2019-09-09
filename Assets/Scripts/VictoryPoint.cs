using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryPoint : MonoBehaviour
{
    [SerializeField] private GameObject _levelCompletedCanvas;
    [SerializeField] private CoinController _coinController;
    [SerializeField] private TextMeshProUGUI _timerText;

    private bool _bFreezeTimer;
    private float _timer;
    
    private void Start()
    {
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

    private void WonGame()
    {
        _levelCompletedCanvas.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerController>();

        if (player)
        {
            _bFreezeTimer = true;

            if (_coinController.AllCoinsCollected())
            {
                WonGame();
                return;
            }

            SceneManager.LoadScene(0);
        }
    }
}
