using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ExtendedSwordState : BaseState
{

    [SerializeField] int extendedAttackdRange = 10;
    [SerializeField] int increasedRepulseForce = 10;

    private string attackInput;
    public Collider2D[] target;
    [SerializeField] private Transform attackPos;
    [SerializeField] private LayerMask opponentLayer;
    private TestMovement2D testMovement2D;
    protected GameObject attackedObject;

    public override void EnterState(AttackStateManager context)
    {
        context.GetComponent<PlayerInput>();
        context.GetComponent<Transform>();
        context.GetComponent<TestMovement2D>();
    }

    public override void UpdateState(AttackStateManager context)
    {
        if (Input.GetButtonDown(attackInput))
        {
            target = Physics2D.OverlapCircleAll(attackPos.position, extendedAttackdRange, opponentLayer);
            testMovement2D.anim.SetBool("Attack 1", true);
            for (int i = 0; i < target.Length; i++)
            {
                attackedObject = target[i].gameObject;
                target[i].attachedRigidbody.AddForce(new Vector2(testMovement2D.facingDirection * increasedRepulseForce, 0), ForceMode2D.Impulse);
            }
        }
        else
        {
            testMovement2D.anim.SetBool("Attack 1", false);
        }
    }

    public override void OnCollisionEnter2D(AttackStateManager context, Collision2D collision)
    {
            
    }
}
