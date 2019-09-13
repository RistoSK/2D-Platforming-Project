using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : KinematicObject
{
    public enum PlayerState
    {
        Grounded,
        PrepareToJump,
        Jumping,
        InFlight,
        Landed
    }

    [SerializeField] private Transform _respawnPositionTransform;
    [SerializeField] private bool _bIsControllerAttached = true;
    [SerializeField] private float _respawnTime = 1.2f;
    [SerializeField] private AudioClip _deathAudio;
    [SerializeField] private AudioClip _respawnAudio;

    public PlayerState playerState;

    private Animator _animator;
    private Collider2D _collider;

    private void Start()
    {
        playerState = PlayerState.Grounded;

        _collider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
    }

    protected override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            playerState = PlayerState.PrepareToJump;
        }

        if (bIsJumping)
        {
            JumpMomentum();
        }

        base.Update();
    }

    private void FixedUpdate()
    {
        if (!_bIsControllerAttached)
        {
            return;
        }

        if (transform.position.y < -25f)
        {
            PlayerDied();
        }

        if (playerState != PlayerState.Grounded)
        {
            UpdateJumpingPlayerState();
        }
        else
        {
            _animator.SetFloat("VelocityX", Mathf.Abs(movement.x));
        }

        if (!CheckIfPlayerIsIdle())
        {
            Move();
        }
    }

    public void PlayerDied()
    {
        audioSource.PlayOneShot(_deathAudio);
        _bIsControllerAttached = false;
        _collider.enabled = false;
        rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        _animator.SetTrigger("Dead");

        StartCoroutine(Respawn());
    }

    public void AttachPlayerControl()
    {
        _bIsControllerAttached = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.gameObject.GetComponent<EnemyController>();

        if (enemy != null)
        {
            if (playerState != PlayerState.Grounded)
            {
                Bounce(enemy._playerBounceForce);
            }
            else
            {
                PlayerDied();
            }
        }
    }

        private void UpdateJumpingPlayerState()
    {
        switch (playerState)
        {
            case PlayerState.PrepareToJump:
                playerState = PlayerState.Jumping;
                _animator.SetBool("Jumping", bIsJumping);
                break;
            case PlayerState.Jumping:
                if (!_bIsGrounded)
                {
                    playerState = PlayerState.InFlight;
                }
                break;
            case PlayerState.InFlight:
                if (_bIsGrounded)
                {    
                    playerState = PlayerState.Landed;
                }
                break;
            case PlayerState.Landed:
                _animator.SetBool("Landed", true);
                break;
        }
    }

    private void PlayerLanded()
    {
        bIsJumping = false;

        _animator.SetBool("Jumping", bIsJumping);
        _animator.SetBool("Landed", false);

        playerState = PlayerState.Grounded;
    }

    private IEnumerator Respawn()
    {       
        yield return new WaitForSeconds(_respawnTime);
        _collider.enabled = true;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        transform.position = _respawnPositionTransform.position;
        _animator.SetTrigger("Respawn");
        audioSource.PlayOneShot(_respawnAudio);
    }
}
