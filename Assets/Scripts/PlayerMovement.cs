using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : NetworkBehaviour
{
    [SyncVar]
    public float movementInput;
    public float speed;
    
    public void Update()
    {
        GetComponent<Rigidbody2D>().velocity =
            new Vector2(GetComponent<PlayerInput>().rawInputMovement * speed, GetComponent<Rigidbody2D>().velocity.y);
    }
}
