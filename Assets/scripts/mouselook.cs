using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class mouselook : MonoBehaviour
{
    public float sensitivity = 100f;
    public Transform player;
    float xrotation;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;// hiding the cursor
    }

     
    void Update()
    {
        // float mousex = Input.GetAxis("Mouse X") * sensitivity;
        // float mousey = Input.GetAxis("Mouse Y") * sensitivity;

        float mousex = 0;
        float mousey = 0;
        
        if(Mouse.current != null)
        {
            mousex = Mouse.current.delta.ReadValue().x*sensitivity;
            mousey= Mouse.current.delta.ReadValue().y*sensitivity;
        }
        if(Gamepad.current != null)
        {
            mousex = Gamepad.current.rightStick.ReadValue().x;
            mousey= Gamepad.current.leftStick.ReadValue().y;
        }

        xrotation -= mousey * Time.deltaTime;

        xrotation = Mathf.Clamp(xrotation,-80, 80);

        transform.localRotation = Quaternion.Euler(xrotation, 0f,0f);

        player.Rotate(Vector3.up * mousex * Time.deltaTime);
        
    }
}
