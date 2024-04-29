using TMPro;
using UnityEngine;

public class TestAttack : MonoBehaviour, IPushable
{

    [SerializeField] protected float attackRange;
    [SerializeField] public float repulseForce;
    [SerializeField] int knocBackCount;
    [SerializeField] float knockBackInterval;
    [SerializeField] float blockTime, blockPauseTimer;
    [SerializeField] float playerIndicationTimer;
    [SerializeField] bool startPlayerIndicationTimer;

    [SerializeField] protected Transform originalAttackPos, attackPos, upAttackPos;
    [SerializeField] protected LayerMask opponentLayer;
    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] TMP_Text Knockbacktracker;

    public float tracker;

    public string attackInput, blockInput, verticalInput;
    public string crouchInput;
    public bool isBlocking;
    public bool isKnockBacked;
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
                Debug.Log("Knockbakced");
                target[i].attachedRigidbody.AddForce(new Vector2(testMovement2D.facingDirection * repulseForce, 0), ForceMode2D.Impulse);

                isKnockBacked = true;
                repulseForce++;
                KnockBackTrack();

                spriteRenderer = target[i].GetComponent<SpriteRenderer>();
                var sprite = spriteRenderer;
                sprite.color = Color.red;
                startPlayerIndicationTimer = true;


                isKnockBacked = true;
                KnockBackTrack();
            }
        }
        else
        {
            testMovement2D.anim.SetBool("Attack 1", false);
            isKnockBacked = false;
        }
    }

    void AttackUpwards()
    {
        float joystickUp = Input.GetAxis(verticalInput);

        if (joystickUp < -0.5f)
        {
            Debug.Log(joystickUp);
            attackPos.position = upAttackPos.position;
        }

        else
        {
            Debug.Log(joystickUp);
            attackPos.position = originalAttackPos.position;
        }
    }

    public void Push(Vector2 direction)
    {
        repulseForce++;
        testMovement2D.playerRb.AddForce(repulseForce * direction);
        testMovement2D.stunned = true;
        tracker = repulseForce;
        Knockbacktracker.text = tracker.ToString();
    }
    void Block() //3 or more attacks can break the block
    {
        if (Input.GetButton(blockInput))
        {
            Debug.Log("Blocked");

            blockTime += Time.deltaTime;
            if (blockTime <= 3)
            {
                testMovement2D.playerRb.constraints = RigidbodyConstraints2D.FreezeAll;
            }

            if (blockTime > 3)
            {
                testMovement2D.playerRb.constraints = RigidbodyConstraints2D.None;
                testMovement2D.playerRb.constraints = RigidbodyConstraints2D.FreezeRotation;
                blockTime = 0;
            }
            testMovement2D.anim.SetBool("Block", true);
        }

        if (Input.GetButtonUp(blockInput))
        {
            testMovement2D.playerRb.constraints = RigidbodyConstraints2D.None;
            testMovement2D.playerRb.constraints = RigidbodyConstraints2D.FreezeRotation;
            blockTime = 0;
            testMovement2D.anim.SetBool("Block", false);
        }
    }

    void KnockBackTrack()
    {
        knocBackCount++;
        Knockbacktracker.text = "" + knocBackCount;

        if (knocBackCount % 2 == 0)
        {
            knocBackCount += 6;
        }


        else if (knocBackCount >= 200f)
        {
            knocBackCount = 0;
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
        AttackUpwards();
        testMovement2D.anim.SetBool("Damge", true);
        if (isKnockBacked)
        {
            playerIndicationTimer += Time.deltaTime;
        }


        else if (!isKnockBacked)
        {
            playerIndicationTimer = 0;
            startPlayerIndicationTimer = false;
        }
        if (!startPlayerIndicationTimer)
        {
            spriteRenderer.color = Color.white;
            testMovement2D.anim.ResetTrigger("Damge");
        }
    }

}
