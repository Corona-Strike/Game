using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class keyBoardControl : MonoBehaviour
{
    
    private CharacterController _charController;

    public float speed;

    public float jumpSpeed;

    public float gravity;

    private Vector3 moveDir = default;

    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed += 5f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed -= 5f;
        }

        if (_charController.isGrounded)
        {
            Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDir = dir;
            moveDir = transform.TransformDirection(moveDir);
            moveDir *= speed;

            if (Input.GetButton("Jump"))
                moveDir.y = jumpSpeed;
        }

        moveDir.y -= gravity * Time.deltaTime;
        _charController.Move(moveDir * Time.deltaTime);
    }
}