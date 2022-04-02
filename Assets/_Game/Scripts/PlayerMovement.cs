using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Camera mainCamera = null;

    //Rigidbody _rb = null;
    public CharacterController controller;

    public float speed = 12f;
    public float run = 1.5f;
    public float jumpHeight = 3f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    float runMultiplyer = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        //check if player is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //Running
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            runMultiplyer = run;
            //Debug.Log("Gotta go fast! Run Multiplyer == " + runMultiplyer);
        }
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            runMultiplyer = 1f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //move character with a and d
        Vector3 move = ((transform.right * h) + (transform.forward * v));

        //move with respect to speed and time
        controller.Move(move * (speed * runMultiplyer) * Time.deltaTime);

        //jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            //_playerSounds.PlayOneShot(jumpSound, 1f);
        }

        //set velocity to gravity
        velocity.y += gravity * Time.deltaTime;

        //move with velocity with time squared
        controller.Move(velocity * Time.deltaTime);
    }
}
