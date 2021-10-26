using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : NetworkBehaviour
{
    public Input input;
    public float rawInputMovement;
    public double lastShootTime;
    public double lastJumpTime;
    public Vector2 cursor;

    public float controllerMouseSpeed;

    private void Update()
    {
        if (!hasAuthority)
            return;
        
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        rawInputMovement = value.ReadValue<float>();
    }
    
    public void OnShoot(InputAction.CallbackContext value)
    {
        lastShootTime = Time.time;
    }
    
    public void OnJump(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            lastJumpTime = Time.time;
        }
    }

    public void OnCursorPosition(InputAction.CallbackContext value)
    {
        cursor = value.ReadValue<Vector2>();
    }

    public void OnCursorDelta(InputAction.CallbackContext value)
    {
        cursor += value.ReadValue<Vector2>() * controllerMouseSpeed;
    }
}
