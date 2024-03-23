using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch : PlayerJump
{
    public void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetButtonDown("Crouch"))
        {
            if (isGrounded)
            {
                capsuleCollider.offset = new Vector2(0, -0.5f);
                capsuleCollider.size = new Vector2(1, 1);
                gameObject.transform.localScale = new Vector2(1, 0.5f);
                states = States.crouch;
            }
        }

        else if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetButtonUp("Crouch"))
        {
            if (isGrounded || !isGrounded)
            {
                capsuleCollider.offset = new Vector2(0, 0);
                capsuleCollider.size = new Vector2(1, 2);
                gameObject.transform.localScale = new Vector2(1, 1f);
                states = States.idle;
            }
        }
    }

    public void Update()
    {
       
    }
}
