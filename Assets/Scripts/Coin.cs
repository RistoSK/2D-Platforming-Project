using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Animator _animator;
    private CoinController _coinController;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _coinController = GetComponentInParent<CoinController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _animator.SetTrigger("Collected");
        _coinController.GainedCoin();
    }

    private void Collected()
    { 
        Destroy(gameObject);
    }
}

