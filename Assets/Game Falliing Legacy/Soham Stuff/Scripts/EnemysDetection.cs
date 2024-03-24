using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysDetection : EnemyMove
{
    [SerializeField] LayerMask playerLayer;

    [SerializeField] float detectionRange, chaseSpeed;

    [SerializeField] bool isChase;

    Collider2D[] detectPlayer;
    GameObject detectedPlayer;

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
        if(isChase)
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
            Debug.Log("Health Decreased");
        }
    }

    private void Update()
    {
        DetectPlayer();
        EnemyPatrol();
        Chase();
    }
}
