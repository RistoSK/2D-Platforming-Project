using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Animator _animator;
    private CoinManager _coinManager;
    private bool _bCollected;

    private void Start()
    {
        _bCollected = false;
        _animator = GetComponent<Animator>();
        _coinManager = GetComponentInParent<CoinManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_bCollected)
        {
            _animator.SetTrigger("Collected");
            _coinManager.GainedCoin();
            _bCollected = true;
        }
    }

    private void Collected()
    { 
        Destroy(gameObject);
    }
}

