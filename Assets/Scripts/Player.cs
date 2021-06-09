using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D box;
    Animator anim;
    bool isFacingRight = true;
    [SerializeField] float offset;
    [SerializeField] float force = 5f;
    [SerializeField] float speed = 5f;
    [SerializeField] LayerMask groundLayerMask;
    void Start()
    {
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Jump();
        Move();
    }
    void Jump()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce( Vector3.up * force, ForceMode2D.Impulse);
        }

    }
    bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector2.down, 0.1f, groundLayerMask);
        return raycastHit.collider != null;
    }
    void Move()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * move, rb.velocity.y);

        //if (move > 0 && !isFacingRight)
        if (UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x && !isFacingRight)
            Flip();
        if (UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x && isFacingRight)
            Flip();
    }
    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        isFacingRight = !isFacingRight;
    }
}
