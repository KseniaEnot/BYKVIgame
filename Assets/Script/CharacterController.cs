using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Vector2 moveDir;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    [SerializeField] private float speed;
    private void Awake()
    {
        moveDir = Vector2.zero;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        //вынести в функцию получе
        moveDir.x = Input.GetAxisRaw("Horizontal");
        if (moveDir.x < 0) sr.flipX = true;
        else if (moveDir.x > 0) sr.flipX = false;
        moveDir.y = Input.GetAxisRaw("Vertical");
        moveDir = moveDir.normalized;

        rb.velocity = moveDir * Time.deltaTime * speed;
    }
}
