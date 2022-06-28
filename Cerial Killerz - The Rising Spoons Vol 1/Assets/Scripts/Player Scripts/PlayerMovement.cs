using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    int jumpCount = 0;
    public int maxJumps = 2;
    public float MovementSpeed = 2.0f;
    public float JumpSpeed = 4f;
    public float groundRadiusCheck = 0.3f;
    public LayerMask layers;
    public float gravityMultiplier = 4f;

    public SpoonThrow spoonThrow;

    public GameObject spoonPrefab;

    public Transform model;



    CharacterController charControl;
    float moveInput;
    bool jumpInput = false;
    public Vector3 currentVelocity;


    void Awake()
    {
        charControl = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (spoonThrow == null)
                spoonThrow = Instantiate(spoonPrefab, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation).GetComponent<SpoonThrow>();

            spoonThrow.transform.position =  new Vector3(transform.position.x, transform.position.y, transform.position.z);
            spoonThrow.transform.rotation = transform.rotation;
            spoonThrow.gameObject.SetActive(true);
            spoonThrow.Throw();
           // GameObject clone;
            //
        }

        moveInput = Input.GetAxis("Horizontal");
        jumpInput = Input.GetButtonDown("Jump");

        Move();
    }

    public void Teleport(Transform direction)
    {
        charControl.enabled = false;
        transform.position = direction.position;
        charControl.enabled = true;
    }


    void Move()
    {
        currentVelocity.x = moveInput * MovementSpeed ;

        //Turn player
        if(moveInput > 0)
        {
            model.rotation = Quaternion.Euler(0,-90,0);
        }else if(moveInput < 0)
        {
             model.rotation = Quaternion.Euler(0,90,0);
        }

        if(charControl.isGrounded)
         {
            currentVelocity.y = 0;
            jumpCount = 0;
        }

        float tempGravMultiplier =1;

        if(currentVelocity.y < 0)
            tempGravMultiplier = gravityMultiplier;

        currentVelocity.y += Physics.gravity.y * tempGravMultiplier* Time.deltaTime;



        if(jumpInput == true && jumpCount < maxJumps)
        {
            jumpCount++;
            currentVelocity.y = JumpSpeed;
        }

        currentVelocity.z = 0;

        charControl.Move(currentVelocity * Time.deltaTime);

        Vector3 pos = transform.position;
        pos.z =0;
        transform.position = pos;

        //if(gameHasBugs)
        //{
        //  FixAllBugs();
        //}
        
    }
}
