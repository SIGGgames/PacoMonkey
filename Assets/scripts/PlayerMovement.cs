using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private float _horizontal;
    private const float DEFAULT_MOVE_SPEED = 5f;

    [SerializeField] float moveSpeedX = DEFAULT_MOVE_SPEED;
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

    // This is the default vertical position where the player will no longer be alive
    private const float DefaultVerticalFallPosition = -10f;


    private void Awake() {
        // Used to initialise an object's own reference
        _rigidbody2D = GetComponent<Rigidbody2D>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    // Start is called before the first frame update
    private void Start() {
        // Used to use or create other object's references
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

        if (Input.GetKey(KeyCode.LeftShift)) {
            if (isYoung) {
                moveSpeedX = DEFAULT_MOVE_SPEED * 1.5f;
            }
            else {
                moveSpeedX = DEFAULT_MOVE_SPEED * 1.7f;
            }
        }
        else {
            moveSpeedX = DEFAULT_MOVE_SPEED;
        }

        Debug.Log("El moveSpeed es: " + moveSpeedX);
        _rigidbody2D.velocity = new Vector2(_horizontal * moveSpeedX, _rigidbody2D.velocity.y);
    }

    /**
     * HandleJump(): Handles the player's jump
     */
    private void HandleJump() {
        if (!isYoung) {
            maxJumps = 1;
        }
        else {
            maxJumps = 2;
        }

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
    private void Jump(float extraJumpForce = 1f) {
        _jumpCounter++;
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, GetJumpForce(extraJumpForce));
    }

    /**
     * GetJumpForce(): Returns the jump force of the player depending on its age (young or old)
     */
    private float GetJumpForce(float extraJumpForce) {
        if (isYoung) {
            const float multiplier = 1 / 3f; // 1/3 is the ratio between the jump force of the old and young player
            return jumpForce * (1 + multiplier) * extraJumpForce;
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