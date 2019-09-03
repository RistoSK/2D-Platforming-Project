﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicObject : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _bounceForce = 12f;

    [SerializeField] private Transform _groundCheckTransform;
    [SerializeField] private float _groundCheckRadius;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] protected bool _bIsGrounded;

    protected Rigidbody2D _rb;
    protected Vector2 _movement;
    protected bool _bIsJumping;

    private float _jumpTimeLimit = 0.5f;
    private float _jumpTimeCounter;
    private SpriteRenderer _spriteRenderer;

    protected virtual void Update()
    {
        _bIsGrounded = Physics2D.OverlapCircle(_groundCheckTransform.position, _groundCheckRadius, _groundLayer);
        _movement = Vector2.zero;
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _movement.x = Input.GetAxisRaw("Horizontal");

        if (_movement.x > 0.01f)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_movement.x < -0.01f)
        {
            _spriteRenderer.flipX = true;
        }
    }

    protected void Bounce()
    {
        _rb.AddForce(new Vector2(0, _bounceForce), ForceMode2D.Impulse);
    }

    protected bool CheckIfPlayerIsIdle()
    {
        return _movement.x == 0 && _movement.y == 0;
    }

    protected void Jump()
    {
        if (_bIsGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            _bIsJumping = true;
            _jumpTimeCounter = _jumpTimeLimit;
            _rb.velocity = Vector2.up * _jumpForce;
        }
    }

    protected void JumpMomentum()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (_jumpTimeCounter > 0)
            {
                _rb.velocity = Vector2.up * _jumpForce;
                _jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                _bIsJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            _bIsJumping = false;
        }
    }

    protected void Move()
    {
        _rb.position = _rb.position + _movement.normalized * Time.deltaTime * _speed;
    }
}