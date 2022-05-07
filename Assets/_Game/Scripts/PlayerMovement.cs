using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //[SerializeField] Camera mainCamera = null;

    [SerializeField] Animator animator = null;
    [SerializeField] private PlayerPosSO playerSO = null;
    //[SerializeField] AudioClip _footstep = null;
    AudioSource audSauce = null;

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
    float aniSlow = 0.04f;
    public bool frozen = false;

    // Start is called before the first frame update
    void Start()
    {
        frozen = false;
        audSauce = GetComponent<AudioSource>();

        //move player to saved position
        //default == 580, 339.29, 1131.4
        transform.position = playerSO.PlayerPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(!frozen)
            Move();
        else
            audSauce.Stop();
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

        animator.SetInteger("xInput", (int)Mathf.Floor(h));
        animator.SetInteger("yInput", (int)Mathf.Floor(v));
        if(h == 0 && v == 0)
        {
            audSauce.Stop();
            if (animator.speed > aniSlow)
            {
                animator.speed -= aniSlow;
            }
            else
            {
                animator.speed = 0;
                //animator.time = 0;
                jumpToTime(currentAnimationName(), 0f);
            }
        }
        else
        {
            animator.speed = 1;

            if (!audSauce.isPlaying)
                audSauce.Play();
        }

        
        /*
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
        */

        //float h = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");

        //move character with a and d
        Vector3 move = ((transform.right * h) + (transform.forward * v));

        //move with respect to speed and time
        controller.Move(move * (speed * runMultiplyer) * Time.deltaTime);

        /*
        //jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            //_playerSounds.PlayOneShot(jumpSound, 1f);
        }
        */

        //set velocity to gravity
        velocity.y += gravity * Time.deltaTime;

        //move with velocity with time squared
        controller.Move(velocity * Time.deltaTime);
    }

    void jumpToTime(string name, float nTime)
    {
        animator.Play(name, 0, nTime);
    }

    string currentAnimationName()
    {
        var currAnimName = "";
        foreach (AnimationClip clip in animator.runtimeAnimatorController.animationClips)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName(clip.name))
            {
                currAnimName = clip.name.ToString();
            }
        }

        return currAnimName;
    }

    public void SavePosition()
    {
        playerSO.PlayerPosition = transform.position;
        audSauce.Stop();
    }
}
