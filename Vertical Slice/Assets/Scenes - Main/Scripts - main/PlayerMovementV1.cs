using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementV1 : MonoBehaviour
{
    // this is for movement
    public float moveSpeed = 5.0f;
    public float jumpForce = 10.0f;

    // need something to check if the ground works
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer; 

    private Rigidbody2D rb;
    public bool isGrounded;
    public float moveInput; 
    // orignally it was private bool isGrounded, however I changed it to public for my visual scripting graph 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        isGrounded= Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        //Debug.Log(isGrounded);
        // for moving the sprites side by side 
        if (moveInput > 0)
            sr.flipX = false;
        else if (moveInput < 0)
            sr.flipX = true;
        // jumps either w or space 
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);


        }
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    SpriteRenderer sr;
 
    
    
}
