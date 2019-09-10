using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentCoinsText;

    private int _currentCoinsAmount;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        _currentCoinsAmount = 0;
        _currentCoinsText.text = _currentCoinsAmount.ToString();
    }

    public void GainedCoin()
    {
        _currentCoinsAmount++;
        _currentCoinsText.text = _currentCoinsAmount.ToString();

        _audioSource.Play();
    }

    public bool AllCoinsCollected()
    {
        return _currentCoinsAmount == 50;
    }
}
