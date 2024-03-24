using UnityEngine.InputSystem;

public class PlayerCrouch : PlayerJump
{
    public string crouchInput;
    private Attack attack;
    private bool block = false;
    private void Start()
    {
        attack = GetComponent<Attack>();
    }
    public void OnBlock(InputAction.CallbackContext context)
    {
        block = context.action.triggered;
    }
    public void Block()
    {
        if (block)
        {
            if (isGrounded)
            {
                anim.SetBool("Block", true);
                if (attack != null)
                {
                    attack.repulseForce = 0;
                }

            }
        }

        else
        {
            if (isGrounded || !isGrounded)
            {
                anim.SetBool("Block", false);
            }
        }
    }

}
