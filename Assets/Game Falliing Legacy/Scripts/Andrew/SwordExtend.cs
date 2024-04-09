using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordExtend : TestAttack
{

    [SerializeField] int extendedRange = 5;
    [SerializeField] int increasedForce = 5;

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("Extend Ability"))
        {
            PlayerAttack();
        }
    }

    public override void PlayerAttack()
    {
        if (Input.GetButtonDown(attackInput))
        {
            target = Physics2D.OverlapCircleAll(attackPos.position, attackRange + extendedRange, opponentLayer);
            testMovement2D.anim.SetBool("Attack 1", true);
            for (int i = 0; i < target.Length; i++)
            {
                attackedObject = target[i].gameObject;
                target[i].attachedRigidbody.AddForce(new Vector2(testMovement2D.facingDirection * repulseForce + increasedForce, 0), ForceMode2D.Impulse);
            }
        }
        else
        {
            testMovement2D.anim.SetBool("Attack 1", false);
        }
    }

}
