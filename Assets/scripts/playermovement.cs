using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playermovement : MonoBehaviour
{
    public  CharacterController characterController;
    public float speed = 15f;
    private Vector3 move;

    public float gravity = -10f;
    public float jumpheight = 4f;
    private Vector3 velocity;

    public Transform groundCheck;
    public float grounddistance = 0.4f;
    public LayerMask groundmask;
    private bool isgrounded;
    public Animator animator;
    InputAction movement;
    InputAction jump;
    void Start()
    {
        jump = new InputAction("Jump", binding: "<keyboard>/space");
        jump.AddBinding("<Gamepad>/a");

        //! just for gamepad
        movement = new InputAction("Movement",binding:"<Gamepad>/leftStick");

        //! just for keyboard inputs
        movement.AddCompositeBinding("Dpad")
        .With("Up", "<keyboard>/w")
        .With("Up", "<keyboard>/upArrow")
        .With("Down", "<keyboard>/s")
        .With("Down", "<keyboard>/downArrow")
        .With("Right", "<keyboard>/d")
        .With("Right", "<keyboard>/rightArrow")
        .With("Left", "<keyboard>/a")
        .With("Left", "<keyboard>/leftArrow");
         movement.Enable();
         jump.Enable();

    }

    void Update()
    {

            isgrounded = Physics.CheckSphere(groundCheck.position, grounddistance, groundmask);

        if(isgrounded && velocity.y<0)
        {
            velocity.y = -2f;
        }

        // float x = Input.GetAxisRaw("Horizontal");
        // float z = Input.GetAxisRaw("Vertical");

        float x = movement.ReadValue<Vector2>().x;
        float z = movement.ReadValue<Vector2>().y;
        animator.SetFloat("speed",Mathf.Abs(x)+Mathf.Abs(z));

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move*speed*Time.deltaTime);

        if(Mathf.Approximately(jump.ReadValue<float>(),1)&& isgrounded) 
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f *  gravity );
        }
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity*Time.deltaTime);



}
}
