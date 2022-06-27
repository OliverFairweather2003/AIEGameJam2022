using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed = 2.0f;
    public float JumpSpeed = 4f;
    public float groundRadiusCheck = 0.3f;
    public LayerMask layers;
    public float gravityMultiplier = 4f;
    CharacterController charControl;
    float moveInput;
    bool jumpInput = false;
    Vector3 currentVelocity;


    void Awake()
    {
        charControl = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        jumpInput = Input.GetButton("Jump");
    }



    private void FixedUpdate () 
    {

        currentVelocity.x = moveInput * MovementSpeed ;

        if(charControl.isGrounded)
            currentVelocity.y = 0;

        float tempGravMultiplier =1;

        if(currentVelocity.y < 0)
            tempGravMultiplier = gravityMultiplier;

        currentVelocity.y += Physics.gravity.y * tempGravMultiplier* Time.deltaTime;



        if(jumpInput == true && charControl.isGrounded == true)
        {
            currentVelocity.y = JumpSpeed;
        }

        currentVelocity.z = 0;

        charControl.Move(currentVelocity * Time.deltaTime);

    }
}
