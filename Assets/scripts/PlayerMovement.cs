using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody2D _rigidbody2D;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    private bool _isGrounded;
    int jumpsCounter = 0;

    private void Awake() {
        // Used to initialise an object's own reference
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    private void Start() // Used to use or create other object's references
    {
    }

    // TODO: Fix double jump
    // TODO: Set border for player movement
    // TODO: Set animation for player movement
    // TODO: Fix player movement when jumping

    // Update is called once per frame
    private void Update() {
        bool wasGrounded = _isGrounded;
        bool moveUp = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) ||
                      Input.GetKeyDown(KeyCode.UpArrow);
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        
        if (_isGrounded && !wasGrounded) {
            jumpsCounter = 0;
        }

        HandleMovement();

        if (moveUp) {
            if (_isGrounded && (!wasGrounded && jumpsCounter < 2)) {
                Jump();
            }
        }

        LimitVelocity();
    }

    private void Jump() {
        _rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        if (!_isGrounded) {
            jumpsCounter++;
        }
    }

    private void HandleMovement() {
        bool moveRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
        bool moveLeft = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        bool moveUp = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) ||
                      Input.GetKeyDown(KeyCode.UpArrow);
        bool moveDown = Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);

        float moveX = 0f;
        float moveY = 0f;

        if (moveRight) {
            moveX = 1;
        }
        else if (moveLeft) {
            moveX = -1;
        }

        if (moveUp) {
            moveY = 1;
        }
        else if (moveDown) {
            moveY = -1;
        }

        Vector2 movement = new Vector2(moveX, moveY);

        if (movement != Vector2.zero) {
            movement = movement.normalized * moveSpeed;
            _rigidbody2D.velocity = movement;
        }
    }

    // Made to visualize the ground detector in the editor
    private void OnDrawGizmosSelected() {
        if (groundCheck == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    private void LimitVelocity() {
        float maxSpeed = 5f;
        if (_rigidbody2D.velocity.magnitude > maxSpeed) {
            _rigidbody2D.velocity = Vector2.ClampMagnitude(_rigidbody2D.velocity, maxSpeed);
        }
    }
}