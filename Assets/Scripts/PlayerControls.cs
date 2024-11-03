using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private GatherInput gInput;
    [Header("Movement")]
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Animator animator;
    private int idSpeedX;

    [Header("Jump")]
    [SerializeField] private float jumpForce;

    [Header("Check Ground")]
    [SerializeField] private float rayLenght;
    [SerializeField] private Transform leftPoint;
    [SerializeField] private Transform rightPoint;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;

    private bool facingRight = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        idSpeedX = Animator.StringToHash("speedX");
    }

    void Update()
    {
        Flip();
        SetAnimationValue();
    }

    private void FixedUpdate()
    {
        GroundCheck();
        Move();
        Jump();
    }

    private void Move()
    {
        rb.velocity = new Vector2(gInput.valueX * speed, rb.velocity.y);
    }

    private void Jump()
    {
        if (gInput.tryToJump)
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(gInput.valueX * speed, jumpForce);
            }

            gInput.tryToJump = false;
        }
    }

    private void Flip()
    {
        if (facingRight && gInput.valueX < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            facingRight = !facingRight;
        }
        else if (!facingRight && gInput.valueX > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            facingRight = !facingRight;
        }
    }

    private void GroundCheck()
    {
        RaycastHit2D hitLeft = Physics2D.Raycast(leftPoint.position, Vector2.down, rayLenght, groundLayer);
        RaycastHit2D hitRight = Physics2D.Raycast(rightPoint.position, Vector2.down, rayLenght, groundLayer);

        if (hitLeft || hitRight)
            isGrounded = true;
        else
            isGrounded = false;
    }

    private void SetAnimationValue()
    {
        animator.SetFloat(idSpeedX, Mathf.Abs(rb.velocity.x));
    }
}
