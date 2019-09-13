using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class CoinManager : MonoBehaviour
{
    public int CurrentCoinAmount { get; private set; }

    private AudioSource _audioSource;

    public UnityAction OnCoinGained;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        CurrentCoinAmount = 0;
    }

    public void GainedCoin()
    {
        CurrentCoinAmount++;

        _audioSource.Play();

        OnCoinGained?.Invoke();
    }

    public bool AllCoinsCollected()
    {
        return CurrentCoinAmount == 50;
    }
}
