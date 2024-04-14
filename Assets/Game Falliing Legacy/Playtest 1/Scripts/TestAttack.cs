using UnityEngine;

public class TestAttack : MonoBehaviour
{
    [SerializeField] protected float attackRange;
    [SerializeField] public float repulseForce;
    [SerializeField] float blockTime, blockPauseTimer;
    [SerializeField] protected Transform attackPos;
    [SerializeField] protected LayerMask opponentLayer;

    public string attackInput, blockInput;
    public string crouchInput;
    public bool isBlocking;
    public Collider2D[] target;
    protected GameObject attackedObject;
    protected TestMovement2D testMovement2D;

    private void Start()
    {
        testMovement2D = GetComponent<TestMovement2D>();

        //attackInput = $"Fire1_P{testMovement2D.OwnId + 1}";
    }

    public virtual void PlayerAttack()
    {
        if (Input.GetButtonDown(attackInput))
        {
            Debug.Log("Attacked");
            target = Physics2D.OverlapCircleAll(attackPos.position, attackRange, opponentLayer);
            print("e");
            testMovement2D.anim.SetBool("Attack 1", true);
            for (int i = 0; i < target.Length; i++)
            {
                Debug.Log(i + " " + target[i].name);
                attackedObject = target[i].gameObject;
                //target[i].attachedRigidbody.velocity = Vector3.zero;
                Debug.Log("Knockbakced");
                target[i].attachedRigidbody.AddForce(new Vector2(testMovement2D.facingDirection * repulseForce, 0), ForceMode2D.Impulse);
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

    void Block() //3 or more attacks can break the block
    {
        if (Input.GetButton(blockInput))
        {
            Debug.Log("Blocked");

            blockTime += Time.deltaTime;
            if (blockTime <= 3)
            {
                //int layerMask = LayerMask.GetMask("Default");
                //gameObject.layer = layerMask;
                testMovement2D.playerRb.constraints = RigidbodyConstraints2D.FreezeAll;
            }

            if (blockTime > 3)
            {
                //int layerMask = LayerMask.GetMask("Opponent");
                //gameObject.layer = layerMask;
                testMovement2D.playerRb.constraints = RigidbodyConstraints2D.None;
                testMovement2D.playerRb.constraints = RigidbodyConstraints2D.FreezeRotation;
                blockTime = 0;
            }
            testMovement2D.anim.SetBool("Block", true);
        }

        if (Input.GetButtonUp(blockInput))
        {
            //int layerMask = LayerMask.GetMask("Opponent");
            //gameObject.layer = layerMask;
            testMovement2D.playerRb.constraints = RigidbodyConstraints2D.None;
            testMovement2D.playerRb.constraints = RigidbodyConstraints2D.FreezeRotation;
            blockTime = 0;
            testMovement2D.anim.SetBool("Block", false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    private void Update()
    {
        PlayerAttack();
        Block();
    }
}
