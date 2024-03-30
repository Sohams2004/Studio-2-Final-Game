using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : PlayerCrouch
{
    public float attackRange, repulseForce;
    [SerializeField] Transform attackPos;
    [SerializeField] LayerMask opponentLayer;
    [SerializeField] GameObject enemyTarget;

    [SerializeField] public float direction;
    private bool beingKnockedBack;
    public string attackInput;

    [SerializeField] PlayerInput playerInput;

    private bool attack = false;
    public void OnAttack1(InputAction.CallbackContext context)
    {
        attack = context.action.triggered;
    }
    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();

        switch (players)
        {
            case Players.Player1:
                horizontalInput = "Horizontal_P1";
                jumpInput = "Jump_P1";
                crouchInput = "Crouch_P1";
                attackInput = "Fire1_P1";
                break;

            case Players.Player2:
                horizontalInput = "Horizontal_P2";
                jumpInput = "Jump_P2";
                crouchInput = "Crouch_P2";
                attackInput = "Fire2_P2";
                break;
        }
    }


    public void PlayerAttack()
    {
        if (attack)
        {

            states = States1.attack;
            anim.SetBool("Attack 1", true);
            Collider2D[] target = Physics2D.OverlapCircleAll(attackPos.position, attackRange, opponentLayer);

            for (int i = 0; i < target.Length; i++)
            {
                enemyTarget = target[i].gameObject;
                enemyTarget.GetComponent<Attack>().OntakeDamage();
            }
        }
        else
        {
            anim.SetBool("Attack 1", false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(attackPos.position, attackRange);
    }

    private void Update()
    {
        PlayerAttack();
        Block();
        Jump();
        GroundCheck();

    }

    private void FixedUpdate()
    {
        if (!beingKnockedBack)
        {
            Movement();
        }

    }
    public void OntakeDamage()
    {
        beingKnockedBack = true;
        playerRb.AddForce(new Vector2(-direction, 0) * repulseForce, ForceMode2D.Impulse);
        Invoke("StopKnockback", 2f);
    }

    void StopKnockback()
    {
        beingKnockedBack = false;
    }
}
