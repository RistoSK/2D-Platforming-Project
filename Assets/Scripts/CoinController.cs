using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentCoinsText;

    private int _currentCoinsAmount;

    private void Start()
    {
        _currentCoinsAmount = 0;
        _currentCoinsText.text = _currentCoinsAmount.ToString();
    }

    public void GainedCoin()
    {
        _currentCoinsAmount++;
        _currentCoinsText.text = _currentCoinsAmount.ToString();
    }
}
