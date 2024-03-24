using UnityEngine;
using UnityEngine.InputSystem;


public class Attack : PlayerCrouch
{
    [SerializeField] float attackRange, repulseForce;
    [SerializeField] Transform attackPos;
    [SerializeField] LayerMask opponentLayer;

    public string attackInput;

    [SerializeField] PlayerInput playerInput;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();

        playerInput = GetComponent<PlayerInput>();

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
                attackInput = "Fire1_P2";
                break;
        }
        SetInput();
    }

    private void SetInput()
    {
        string horizontalAxis = $"Horizontal_P{playerInput.playerIndex + 1}";
        string jumpAxis = $"Jump_P{playerInput.playerIndex + 1}";
        string crouchAxis = $"Crouch_P{playerInput.playerIndex + 1}";
        attackInput = $"Fire1_P{playerInput.playerIndex + 1}";

        horizontalInput = horizontalAxis;
        jumpInput = jumpAxis;
        crouchInput = crouchAxis;

    }

    void PlayerAttack()
    {
        if (Input.GetButtonDown(attackInput))
        {
            Debug.Log("Attacked");
            states = States1.attack;
            Collider2D[] target = Physics2D.OverlapCircleAll(attackPos.position, attackRange, opponentLayer);
            //anim.SetBool("Attack 1", true);
            for (int i = 0; i < target.Length; i++)
            {
                GameObject enemyTarget = target[i].gameObject;
                target[i].attachedRigidbody.AddForce(new Vector2(facingDirection, 0) * repulseForce, ForceMode2D.Impulse);
            }
        }
        else
        {
            //anim.SetBool("Attack 1", false);
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
