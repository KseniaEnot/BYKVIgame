using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public bool canMove; //make private?
    private Vector2 moveDir;
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    [SerializeField] private float speed;
    private void Awake()
    {
        canMove = true;
        moveDir = Vector2.zero;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (canMove) move();
    }

    private void move()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal");
        if (moveDir.x < 0) sr.flipX = true;
        else if (moveDir.x > 0) sr.flipX = false;
        moveDir.y = Input.GetAxisRaw("Vertical");
        if ((moveDir.x == 0) && (moveDir.y == 0))
        {
            animator.SetBool("isIdle", false);
        }
        else
        {
            animator.SetBool("isIdle", true);
        }
        moveDir = moveDir.normalized;

        rb.velocity = moveDir * Time.deltaTime * speed;
    }
}
