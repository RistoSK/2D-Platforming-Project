using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class CoinManager : MonoBehaviour
{
    public int CurrentCoinAmount { get; private set; }

    [SerializeField] private TextMeshProUGUI _currentCoinsText;
    [SerializeField] private TextMeshProUGUI _unfinishedCoinsText;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        _currentCoinsText.text = "0 / 50";
        CurrentCoinAmount = 0;
    }

    public void GainedCoin()
    {
        CurrentCoinAmount++;

        _audioSource.Play();

        _currentCoinsText.text = CurrentCoinAmount + " / 50";
    }

    public bool AllCoinsCollected()
    {
        return CurrentCoinAmount == 50;
    }

    public void SetUnfinishedCoinsText()
    {
        _unfinishedCoinsText.text = CurrentCoinAmount + " / 50";
    }
}
