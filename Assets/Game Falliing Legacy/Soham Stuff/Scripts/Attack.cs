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
            anim.SetBool("Attack 1", true);
            for (int i = 0; i < target.Length; i++)
            {
                GameObject enemyTarget = target[i].gameObject;
                target[i].attachedRigidbody.AddForce(new Vector2(facingDirection, 0) * repulseForce, ForceMode2D.Impulse);
            }
        }
        else
        {
            anim.SetBool("Attack 1", false);
        }
    }

    private void OnDrawGizmos()
    {/*
        Gizmos.DrawSphere(attackPos.position, attackRange);*/
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
