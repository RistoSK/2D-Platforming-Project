using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Animator _animator;
    private CoinController _coinController;
    private bool _bCollected;

    private void Start()
    {
        _bCollected = false;
        _animator = GetComponent<Animator>();
        _coinController = GetComponentInParent<CoinController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_bCollected)
        {
            _animator.SetTrigger("Collected");
            _coinController.GainedCoin();
            _bCollected = true;
        }
    }

    private void Collected()
    { 
        Destroy(gameObject);
    }
}

