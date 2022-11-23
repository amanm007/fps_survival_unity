using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController character_controller;
    private Vector3 move_Direction;
    public float speed = 5f;
    private float gravity = 20f;
    public float jump_Force = 10f;
    private float vertical_velocity;


    private void Awake()
    {
        character_controller = GetComponent<CharacterController>();//gets our character controller

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovethePlayer();


    }
    void MovethePlayer()
    {
        move_Direction = new Vector3(Input.GetAxis(Axis.HORIZONTAL), 0f, Input.GetAxis(Axis.VERTICAL)); //(x,y,z)
        Debug.Log("Horizontal: " + Input.GetAxis("Horizontal"));
        move_Direction = transform.TransformDirection(move_Direction);
        move_Direction *= speed * Time.deltaTime;

        ApplyGravity();

        character_controller.Move(move_Direction);


    }
    void ApplyGravity()
    {
        if(character_controller.isGrounded==true)
        {
            vertical_velocity -= gravity * Time.deltaTime;

            PlayerJump();
        }
        else
        {
            vertical_velocity -= gravity * Time.deltaTime;

        }

        move_Direction.y = vertical_velocity * Time.deltaTime; //y=vertical velocity
    }

    void PlayerJump()
    {
        if(character_controller.isGrounded==true&&Input.GetKeyDown(KeyCode.Space))
        {
            vertical_velocity = jump_Force;
            
        }

    }
}
