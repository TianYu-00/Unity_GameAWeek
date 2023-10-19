using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float movementSpeed;
    public float jumpForce;
    public KeyCode jumpButton;
    AudioSource jumpSound;


    //keycodes //player movement button
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpSound = GetComponent<AudioSource>();


    }

    void jump()
    {

        if (Input.GetKeyDown(jumpButton) && grounded())
            {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            //rb.velocity = Vector2.up * jumpForce;
            jumpSound.Play();

            }

        
    }

    // Update is called once per frame
    void Update()
    {
        jump();
        
        /*float directionX = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + directionX, transform.position.y);*/
    }

    private bool grounded() {
        return transform.Find("GroundChecker").GetComponent<GroundCheckerScript>().isGrounded;

        
    }

    private void FixedUpdate()
    {
        
        float directionX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(directionX * movementSpeed, rb.velocity.y);
    }





}
