using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
public class FirstPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 10f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;
    public float horizontalInput;
    public float verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0){
            velocity.y = 2f;
        }
        float x = horizontalInput;
        float z = verticalInput;

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y =+ gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        bool isWalking = (x != 0 || z != 0);
        //UIManager.instance.SetWalkCheck(isWalking);
    }
    public void OnMoveEvent(InputAction.CallbackContext value)
    {
    Vector2 input = value.ReadValue<Vector2>();
    horizontalInput = input.x;
    verticalInput = input.y;
    }
}



