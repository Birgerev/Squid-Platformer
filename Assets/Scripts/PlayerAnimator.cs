using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerAnimator : NetworkBehaviour
{
    //[SyncVar]
    public float aimDirection;
    
    private Animator anim;
    private PlayerInput input;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        input = GetComponentInParent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateAimAngle();
        
        anim.SetFloat("Aim Direction", aimDirection);
    }

    private void CalculateAimAngle()
    {
        //v = tan-1(deltaY/deltaX)
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(input.cursor);
        Vector2 deltaPos = mousePosition - (Vector2)transform.position;
        float angle = Mathf.Rad2Deg*Mathf.Atan(deltaPos.y / deltaPos.x);
        float direction = 0.5f + (angle / 180);

        SetAimDirection(direction);
    }

    //[Command]
    private void SetAimDirection(float direction)
    {
        aimDirection = direction;
    }
}
