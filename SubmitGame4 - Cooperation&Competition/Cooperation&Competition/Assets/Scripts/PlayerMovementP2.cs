using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementP2 : MonoBehaviour
{
    public float movementSpeed;
    public float jumpForce;
    public KeyCode jumpButton;
    //AudioSource jumpSound;

    private Rigidbody2D rb;
    public Animator anim;
    private float directionX;
    private bool lookRight = false;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //jumpSound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();



    }

    void jump()
    {

        if (Input.GetKeyDown(jumpButton) && grounded())
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            //rb.velocity = Vector2.up * jumpForce;
            //jumpSound.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {

        jump();

        /*float directionX = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + directionX, transform.position.y);*/
    }

    private bool grounded()
    {
        return transform.Find("GroundCheckerP2").GetComponent<GroundCheckerP2>().isGrounded;
    }

    private void FixedUpdate()
    {
        

        directionX = Input.GetAxis("P1_Horizontal");
        rb.velocity = new Vector2(directionX * movementSpeed, rb.velocity.y);
        if (Mathf.Abs(directionX) > 0 && rb.velocity.y == 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (rb.velocity.y == 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }
        if (rb.velocity.y > 0)
        {
            anim.SetBool("isJumping", true);
        }
        if (rb.velocity.y < 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }

        if (directionX > 0 && !lookRight || directionX < 0 && lookRight)
        {
            flipChar(directionX);
        }


    }
    private void flipChar(float directionX)
    {
        lookRight = !lookRight;
        transform.Rotate(Vector2.up * 180);
    }

}
