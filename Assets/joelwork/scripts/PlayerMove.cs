using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float jumpHeight = 3f;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Transform groundCheck;

    Vector3 veclocity;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //isGrounded is a bool that checks if the player is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        //if the bool isGrouned is on and the velocity is less than 0 then make the y veclocity will be -2
        if(isGrounded && veclocity.y < 0)
        {
            veclocity.y = -2f;
        }

        // the float x and z will get the axis of your mouse
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // this will actually move the mouse 
        Vector3 move = transform.right * x + transform.forward * z;

        //this will move the character and use the speed float to control the speed
        controller.Move(move * speed * Time.deltaTime);

        veclocity.y += gravity * Time.deltaTime;

        //will move the controller down to what the gravity is from the line above 
        controller.Move(veclocity * Time.deltaTime);

        // if the button "jump" which is space gets pressed the script will check if the player is grounded and if the player is grounded then the veclocity will change to whatever the float jumpHeight is
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            veclocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        }
    }
}
