using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private float _horizontal;
    public float moveSpeed;
    public float jumpForce;
    public float groundCheckRadius = 0.2f;
    private bool _isFacingRight = true;

    private bool _isJumping = false;
    private float _jumpTimeCounter;
    [SerializeField] private float jumpTime;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private PlayerPos _playerPos;

    private void Awake() {
        // Used to initialise an object's own reference
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    private void Start() {
        // Used to use or create other object's references
        _playerPos = GetComponent<PlayerPos>();
    }

    // Update is called once per frame
    private void Update() {
        // TODO: Move player movement to FixedUpdate() without breaking JUMPS!!!
        _horizontal = Input.GetAxisRaw("Horizontal");

        if (Utils.GetJumpStatus() == 1 && IsGrounded()) {
            _isJumping = true;
            _jumpTimeCounter = jumpTime;
            _rigidbody2D.velocity = Vector2.up * jumpForce;
        }

        if (Utils.GetJumpStatus() == 2 && _isJumping) {
            if (_jumpTimeCounter > 0) {
                _rigidbody2D.velocity = Vector2.up * jumpForce;
                _jumpTimeCounter -= Time.deltaTime;
            }
            else {
                _isJumping = false;
            }
        }

        _rigidbody2D.velocity = new Vector2(_horizontal * moveSpeed, _rigidbody2D.velocity.y);

        HandleFlip();
        CheckFall();
    }

    private void FixedUpdate() {
        // Used to update physics
    }


    /**
     * IsGrounded(): Returns true if the player is touching the ground
     */
    private bool IsGrounded() {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    /**
     * CheckFall(): Checks if the player has fallen off the map and respawns it
     */
    private void CheckFall() {
        if (transform.position.y < -10f) {
            _playerPos.RespawnAtLastCheckpoint();
            //Respawn();
        }
    }

    /**
     * Respawn(): Respawns the player at the initial position
     */
    private void Respawn() {
        Vector2 respawnCoordinates = new Vector2(0, 5);
        transform.position = respawnCoordinates;
        _rigidbody2D.velocity = Vector2.zero;
    }

    /**
     * HandleFlip(): Flips the player sprite when changing direction
     */
    private void HandleFlip() {
        if (_isFacingRight && _horizontal < 0f || !_isFacingRight && _horizontal > 0f) {
            _isFacingRight = !_isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    /**
     * OnDrawGizmosSelected(): Draws a red circle around the ground detector
     */
    private void OnDrawGizmosSelected() {
        if (groundCheck == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}