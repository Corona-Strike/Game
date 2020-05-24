using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class keyBoardControl : MonoBehaviour
{
    
    private CharacterController _charController;

  
    public float speed = 3.0f;

    public float jumpSpeed = 3.0f;

    public float gravity = 4.0f;


    void Start()
    {
  
        _charController = GetComponent<CharacterController>();
    }

    void Update()
    {


        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
       

        movement = Vector3.ClampMagnitude(movement, speed);

        movement *= Time.deltaTime;
     
        movement = transform.TransformDirection(movement);
        if (_charController.isGrounded)
        {

            _charController.Move(movement);

            if (Input.GetButton("Jump"))
            {
                movement = new Vector3(0, jumpSpeed, 0);
                movement = transform.TransformDirection(movement);
            }
        }

        movement.y -= gravity * Time.deltaTime;
        _charController.Move(movement);


    }
}