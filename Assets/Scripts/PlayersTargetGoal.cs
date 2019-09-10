using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayersTargetGoal : MonoBehaviour
{
    [SerializeField] private LevelManager _levelManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerController>();

        if (player)
        {
            _levelManager.WonGame();          
        }
    }
}
