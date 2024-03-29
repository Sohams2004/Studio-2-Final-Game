using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    public float attackRange, repulseForce;
    [SerializeField] Transform attackPos;
    [SerializeField] LayerMask opponentLayer;
    [SerializeField] GameObject enemyTarget;

    public string attackInput;

    [SerializeField] PlayerInput playerInput;

    Movement2D movement;

    private bool attack = false;
    public void OnAttack1(InputAction.CallbackContext context)
    {
        attack = context.action.triggered;
    }
    private void Start()
    {
        movement = FindObjectOfType<Movement2D>();
    }

    void PlayerAttack()
    {
        if (attack)
        {
            Debug.Log("Attacked");
            Collider2D[] target = Physics2D.OverlapCircleAll(attackPos.position, attackRange, opponentLayer);
            movement.anim.SetBool("Attack 1", true);
            for (int i = 0; i < target.Length; i++)
            {
                enemyTarget = target[i].gameObject;
                target[i].attachedRigidbody.AddForce(new Vector2(movement.facingDirection, 0) * repulseForce, ForceMode2D.Impulse);
            }
        }
        else
        {
            movement.anim.SetBool("Attack 1", false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(attackPos.position, attackRange);
    }

    private void Update()
    {
        PlayerAttack();
       

    }

    private void FixedUpdate()
    {
       
    }

}
