using UnityEngine;
using UnityEngine.Events;

public class PlayersTargetGoal : MonoBehaviour
{
    public UnityAction OnLevelFinished;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerController>();

        if (player)
        {
            OnLevelFinished?.Invoke();
        }
    }
}
