using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private const float DefaultMoveSpeed = 3f;

    // This is the default vertical position where the player will no longer be alive
    private const float DefaultVerticalFallPosition = -10f;
    private const float YoungJumpForceMultiplier = 1.3f; // 30% more jump force when jumping (young)
    private const float YoungSpeedXMultiplier = 1.8f; // 80% more speed when running (young)
    private const float OldSpeedXMultiplier = 2.4f; // 140% more speed when running (old)
    private const float PreJumpDistance = 3.5f; // Distance from the ground to allow pre-jumping

    private bool _isPreJumping = false;
    private float _horizontal;
    [SerializeField] float moveSpeedX = DefaultMoveSpeed;
    public float groundCheckRadius = 0.2f;
    public float jumpForce;
    [SerializeField] private int maxJumps;
    private bool _isFacingRight = true;
    [SerializeField] bool isYoung = true;

    private bool _isJumping = false;
    private float _jumpTimeCounter;
    private int _jumpCounter;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private GameMaster gm;


    private void Awake() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    // Start is called before the first frame update
    private void Start() {
        // Used to use or create other object's references
        transform.position = gm.lastCheckPointPosition;
    }

    /**
     * Update(): Used to update the game per frame
     */
    private void Update() {
        HandleInput();
        HandleFlip();
        CheckFall();
    }

    /**
     * FixedUpdate(): Used to update physics
     */
    private void FixedUpdate() {
        // Used to update physics
        HandleMovement();
        HandleJump();
    }

    /**
     * HandleInput(): Handles the player's input
     */
    private void HandleInput() {
        _horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift)) {
            if (isYoung) {
                moveSpeedX = DefaultMoveSpeed * YoungSpeedXMultiplier;
            }
            else {
                moveSpeedX = DefaultMoveSpeed * OldSpeedXMultiplier;
            }
        }
        else {
            moveSpeedX = DefaultMoveSpeed;
        }

        if (Utils.GetJumpInput() && _jumpCounter < maxJumps) {
            if (IsGrounded()) {
                Jump();
            } else if (_jumpCounter < maxJumps && IsNearGround()) {
                _isPreJumping = true;
            }
        }
    }

    /**
     * HandleMovement(): Handles the player's movement
     */
    private void HandleMovement() {
        _rigidbody2D.velocity = new Vector2(_horizontal * moveSpeedX, _rigidbody2D.velocity.y);
    }

    /**
     * HandleJump(): Handles the player's jump
     */
    private void HandleJump() {
        maxJumps = isYoung ? 2 : 1;

        if (IsGrounded()) {
            _isJumping = false;
            if (_isPreJumping) {
                _isPreJumping = false;
                Jump();
            }
        } else {
            _isJumping = true;
        }
    
        if (IsGrounded() && !_isJumping) {
            _jumpCounter = 0;
        }
    }

    /**
    * Jump(): Makes the player jump
    */
    private void Jump(float extraJumpForce = 1f) {
        if (!_isJumping) {
            _jumpCounter++;
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, GetJumpForce(extraJumpForce));
        }
    }

    /**
     * GetJumpForce(): Returns the jump force of the player depending on its age (young or old)
     */
    private float GetJumpForce(float extraJumpForce) {
        if (isYoung) {
            return jumpForce * YoungJumpForceMultiplier * extraJumpForce;
        }

        return jumpForce + 2 * extraJumpForce;
    }


    /**
     * IsGrounded(): Returns true if the player is touching the ground
     */
    private bool IsGrounded() {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    /**
     * IsNearGround(): Returns true if the player is near the ground
     */
    private bool IsNearGround() {
        RaycastHit2D raycastHit = Physics2D.Raycast(groundCheck.position, Vector2.down, PreJumpDistance, groundLayer);
        return raycastHit.collider != null;
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