using UnityEngine;

public class EnemysDetection : EnemyMove
{
    [SerializeField] LayerMask playerLayer;

    [SerializeField] float detectionRange, chaseSpeed;

    [SerializeField] bool isChase;

    Collider2D[] detectPlayer;
    GameObject detectedPlayer;
    public Animation animation;
    public float attackRange, repulseForce;
    [SerializeField] Transform attackPos;
    [SerializeField] LayerMask opponentLayer;
    [SerializeField] GameObject enemyTarget;
    [SerializeField] public float facingDirection;
    private void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();

        isPatrol = true;
    }

    public void DetectPlayer()
    {
        detectPlayer = Physics2D.OverlapCircleAll(transform.position, detectionRange, playerLayer);

        for (int i = 0; i < detectPlayer.Length; i++)
        {
            detectedPlayer = detectPlayer[i].gameObject;

            if (detectedPlayer)
            {
                Debug.Log("Player Detected");
                isPatrol = false;
                isChase = true;
            }
        }
    }

    void Chase()
    {
        if (isChase)
        {
            Vector2 chasePlayer = (detectedPlayer.transform.position - transform.position).normalized;
            enemyRb.velocity = chasePlayer * chaseSpeed;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            Collider2D[] target = Physics2D.OverlapCircleAll(attackPos.position, attackRange, opponentLayer);

            for (int i = 0; i < target.Length; i++)
            {
                enemyTarget = target[i].gameObject;
                target[i].attachedRigidbody.AddForce(new Vector2(facingDirection, 0) * repulseForce, ForceMode2D.Impulse);
            }
        }
    }

    private void Update()
    {
        DetectPlayer();
        EnemyPatrol();
        Chase();
    }
}
