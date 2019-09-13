using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicObject : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    [SerializeField] private Transform _groundCheckTransform;
    [SerializeField] private float _groundCheckRadius;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] protected bool _bIsGrounded;

    [SerializeField] private AudioClip _jumpingAudio;

    protected Rigidbody2D rb;
    protected Vector2 movement;
    protected bool bIsJumping;
    protected AudioSource audioSource;

    private float _jumpTimeLimit = 0.5f;
    private float _jumpTimeCounter;
    private SpriteRenderer _spriteRenderer;
    private float _coyoteTime = 0.3f;
    private float _notGroundedTimer;

    protected virtual void Update()
    {
        _bIsGrounded = Physics2D.OverlapCircle(_groundCheckTransform.position, _groundCheckRadius, _groundLayer);
        movement = Vector2.zero;
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        
        movement.x = Input.GetAxisRaw("Horizontal");

        if (movement.x > 0.01f)
        {
            _spriteRenderer.flipX = false;
        }
        else if (movement.x < -0.01f)
        {
            _spriteRenderer.flipX = true;
        }

        if (!_bIsGrounded)
        {
            if (_notGroundedTimer < _coyoteTime)
            {
                _notGroundedTimer += Time.deltaTime;
            }
        }
        else
        {
            _notGroundedTimer = 0f;
        }
    }

    protected void Bounce(float bounceForce)
    {
        rb.AddForce(new Vector2(0, bounceForce), ForceMode2D.Impulse);
    }

    protected bool CheckIfPlayerIsIdle()
    {
        return movement.x == 0 && movement.y == 0;
    }

    protected void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_bIsGrounded || _notGroundedTimer < _coyoteTime)
            {
                audioSource.PlayOneShot(_jumpingAudio);
                bIsJumping = true;
                _jumpTimeCounter = _jumpTimeLimit;
                rb.velocity = Vector2.up * _jumpForce;
                _notGroundedTimer = _coyoteTime;
            }
        }
    }

    protected void JumpMomentum()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (_jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * _jumpForce;
                _jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                bIsJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            bIsJumping = false;
        }
    }

    protected void Move()
    {
        rb.position = rb.position + movement.normalized * Time.deltaTime * _speed;
    }
}
