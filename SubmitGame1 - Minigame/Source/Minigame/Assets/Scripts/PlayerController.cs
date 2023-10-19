using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables
    public CharacterController controller;
    public float speed = 12f;

    //gravity
    Vector3 velocity;
    public float gravity = -9.81f;

    //Check Ground
    public Transform groundChecker;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    //Jump
    public float jumpHeight = 3f;

    //Animation
    public Animator anim;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        //Check to see if its grounded
        isGrounded = Physics.CheckSphere(groundChecker.position,groundDistance, groundMask); //check the ground
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z; //direction based on x and z movement and facing
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //Jump
        // v=/- hx-2xg
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); 
        }

        //Animations
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Vertical")) ));


    }
}
