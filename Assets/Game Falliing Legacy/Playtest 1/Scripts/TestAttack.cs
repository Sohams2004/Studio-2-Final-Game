using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.VersionControl.Asset;

public class TestAttack : MonoBehaviour
{
    [SerializeField] float attackRange;
    [SerializeField] public float repulseForce;
    [SerializeField] Transform attackPos;
    [SerializeField] LayerMask opponentLayer;

    public string attackInput, xyz;

    public Collider2D[] target;
    GameObject attackedObject;
    TestMovement2D testMovement2D;
    KnockBackObject knockBackObject;

    private void Start()
    {
        testMovement2D = FindObjectOfType<TestMovement2D>();
    }

    void PlayerAttack()
    {
        if (Input.GetButtonDown(attackInput))
        {
            Debug.Log("Attacked");
            target = Physics2D.OverlapCircleAll(attackPos.position, attackRange, opponentLayer);
            testMovement2D.anim.SetBool("Attack 1", true);
            for (int i = 0; i < target.Length; i++)
            {
                Debug.Log(i + " " + target[i].name);
                attackedObject = target[i].gameObject;
                //target[i].attachedRigidbody.velocity = Vector3.zero;
                Debug.Log("Knockbakced");
                target[i].attachedRigidbody.AddForce(new Vector2(testMovement2D.facingDirection * repulseForce, 0) , ForceMode2D.Impulse);
                //target[i].attachedRigidbody.velocity = new Vector2(testMovement2D.facingDirection, 0) * repulseForce;
                /*knockBackObject = gameObject.GetComponent<KnockBackObject>();
                if (knockBackObject is not null)
                {
                    Vector2 knockBackDirection = (transform.position - attackPos.position).normalized;
                }*/
            }
        }
        else
        {
            testMovement2D.anim.SetBool("Attack 1", false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    private void Update()
    {
        PlayerAttack();
    }
}
