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

    [SerializeField] private int maxJumps;

    private bool _isJumping;
    private int _jumpCounter;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private void Awake() {
        // Used to initialise an object's own reference
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    private void Start() {
        // Used to use or create other object's references
    }

    // Update is called once per frame
    private void Update() {
        HandleMovement();
        HandleJump();
        HandleFlip();
        CheckFall();
    }

    private void FixedUpdate() {
        // Used to update physics
    }

    private void HandleMovement() {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _rigidbody2D.velocity = new Vector2(_horizontal * moveSpeed, _rigidbody2D.velocity.y);
    }

    private void HandleJump() {
        if (IsGrounded() && !_isJumping) {
            _jumpCounter = 0;
        }
        else {
            _isJumping = false;
        }

        if (Input.GetButtonDown("Jump") && _jumpCounter < maxJumps - 1) {
            Jump();
        }
    }

    private void Jump() {
        _jumpCounter++;
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
        _isJumping = true;
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
            Respawn();
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