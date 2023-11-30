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
    [SerializeField] private float jumpTime;
    private float _jumpTimeCounter;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private void Awake() {
        // Used to initialise an object's own reference
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // TODO: Fix double jump
    // TODO: Set border for player movement
    // TODO: Set animation for player movement
    // TODO: Fix player movement when jumping

    // Update is called once per frame
    private void Update() {
        _horizontal = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
            _isJumping = true;
            _jumpTimeCounter = jumpTime;
            _rigidbody2D.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && _isJumping) {
            if (_jumpTimeCounter > 0) {
                _rigidbody2D.velocity = Vector2.up * jumpForce;
                _jumpTimeCounter -= Time.deltaTime;
            } else {
                _isJumping = false;
            }
        }

        _rigidbody2D.velocity = new Vector2(_horizontal * moveSpeed, _rigidbody2D.velocity.y);

        Flip();
    }

    private bool IsGrounded() {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void Flip() {
        if (_isFacingRight && _horizontal < 0f || !_isFacingRight && _horizontal > 0f) {
            _isFacingRight = !_isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    
    // Made to visualize the ground detector in the editor
    private void OnDrawGizmosSelected() {
        if (groundCheck == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}