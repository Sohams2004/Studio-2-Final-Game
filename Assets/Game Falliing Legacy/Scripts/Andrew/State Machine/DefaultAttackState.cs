using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DefaultAttackState : BaseState
{
    private string attackInput;
    public Collider2D[] target;
    [SerializeField] private Transform attackPos;
    [SerializeField] private float attackRange = 5;
    [SerializeField] private float repulseForce = 5;
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
            Debug.Log("Attacked");
            target = Physics2D.OverlapCircleAll(attackPos.position, attackRange, opponentLayer);
            testMovement2D.anim.SetBool("Attack 1", true);
            for (int i = 0; i < target.Length; i++)
            {
                attackedObject = target[i].gameObject;
                target[i].attachedRigidbody.AddForce(new Vector2(testMovement2D.facingDirection * repulseForce, 0), ForceMode2D.Impulse);
            }
        }
        else
        {
            testMovement2D.anim.SetBool("Attack 1", false);
        }
    }

    public override void OnCollisionEnter2D(AttackStateManager context, Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Extend Ability"))
        {
            context.SwitchState(context.esState);
        }
    }
}
