using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : PlayerCrouch
{
    [SerializeField] float attackRange, repulseForce;
    [SerializeField] Transform attackPos;
    [SerializeField] LayerMask opponentLayer;

    void PlayerAttack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Attacked");
            states = States.attack;
            Collider2D[] target = Physics2D.OverlapCircleAll(attackPos.position, attackRange, opponentLayer);
            for (int i = 0; i < target.Length; i++)
            {
                GameObject enemyTarget = target[i].gameObject;
                target[i].attachedRigidbody.AddForce(new Vector2(facingDirection, 0) * repulseForce, ForceMode2D.Impulse);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(attackPos.position, attackRange);
    }

    private void Update()
    {
        PlayerAttack();
        Crouch();
        Jump();
        GroundCheck();
    }

    private void FixedUpdate()
    {
        Movement();
    }
}
