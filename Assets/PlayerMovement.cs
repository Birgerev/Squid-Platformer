using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float rawInputMovement;
    public float speed;

    public void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity =
            new Vector2(rawInputMovement * speed, GetComponent<Rigidbody2D>().velocity.y);
    }


    public void OnMovement(InputAction.CallbackContext value)
    {
        rawInputMovement = value.ReadValue<float>();
    }
    
    public void OnFire(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            print("shooting");
        }else
            print("holding");
    }
    
    public void OnJump(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            
        }
    }
}
