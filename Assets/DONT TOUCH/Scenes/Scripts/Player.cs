using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public LayerMask ground;
    public float speed;
    public float jumpSpeed;
    private Rigidbody2D rb;
    bool jumping;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GroundCheck()) 
        {
            jumping = true;
        }
        
    }

    private void FixedUpdate()
    {
        float xMove = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(xMove * speed * Time.deltaTime, rb.velocity.y);

        if (jumping)
        {
            rb.velocity = Vector2.up * jumpSpeed * Time.deltaTime;
            jumping = false;
        }
        
    }

    private bool GroundCheck()
    {
        BoxCollider2D col = GetComponent<BoxCollider2D>();
        return Physics2D.Raycast(transform.position, Vector2.down, col.bounds.extents.y * 2, ground);
    }
}
