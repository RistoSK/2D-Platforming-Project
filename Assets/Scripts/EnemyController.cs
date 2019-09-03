using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private  Transform _patrolPoint1;
    [SerializeField] private  Transform _patrolPoint2;
    [SerializeField] private float _speed = 2f;
    [SerializeField] public float _playerBounceForce = 12f;

    private Animator _animator;
    private Vector3 _destPoint;
    private Rigidbody2D _rb;
    private Collider2D _collider;
    private SpriteRenderer _spriteRenderer;

    private bool _bIsDead;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();

        if (_patrolPoint1 != null)
        {
            _destPoint = _patrolPoint1.position;
        }
        else
        {
            _animator.SetBool("Idle", true);
        }
    }

    private void Update()
    {
        if (_bIsDead || _patrolPoint1 == null)
        {
            return;
        }

        if (Vector2.Distance(transform.position, _destPoint) < 0.5f)
        {
            GotoNextPoint();
        }

        transform.position = Vector2.MoveTowards(transform.position, _destPoint, Time.deltaTime * _speed);
    }

    private void GotoNextPoint()
    {
        if (_destPoint == _patrolPoint1.position)
        {
            _destPoint = _patrolPoint2.position;
            _spriteRenderer.flipX = false;
        }
        else
        {
            _destPoint = _patrolPoint1.position;
            _spriteRenderer.flipX = true;
        }       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            if (player.playerState != PlayerController.PlayerState.Grounded)
            {
                _animator.SetBool("Dead", true);
                _bIsDead = true;
                _collider.enabled = false;
            }
        }
    }

    private void Kill()
    {
        Destroy(gameObject);
    }
}
