using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private float _horizontal;
    public float moveSpeed;
    public float groundCheckRadius = 0.2f;
    public float jumpForce;
    [SerializeField] private int maxJumps;
    private bool _isFacingRight = true;

    private bool _isJumping = false;
    private float _jumpTimeCounter;
    private int _jumpCounter;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private GameMaster gm;

    // This is the default vertical position where the player will no longer be alive
    private const float DefaultVerticalFallPosition = -10f;


    private void Awake() {
        // Used to initialise an object's own reference
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    private void Start() {
        // Used to use or create other object's references
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPosition;
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

    /**
     * HandleMovement(): Handles the player's movement
     */
    private void HandleMovement() {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _rigidbody2D.velocity = new Vector2(_horizontal * moveSpeed, _rigidbody2D.velocity.y);
    }

    /**
     * HandleJump(): Handles the player's jump
     */
    private void HandleJump() {
        if (IsGrounded()) {
            if (_isJumping) {
                _isJumping = false;
                _jumpCounter = 0;
            }
        }
        else {
            _isJumping = true;
        }

        if (Utils.GetJumpInput() && _jumpCounter < maxJumps) {
            Jump();
        }
    }

    /**
    * Jump(): Makes the player jump
    */
    private void Jump() {
        _jumpCounter++;
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
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
        if (transform.position.y < DefaultVerticalFallPosition) {
            PlayerEvents.Respawn();
        }
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