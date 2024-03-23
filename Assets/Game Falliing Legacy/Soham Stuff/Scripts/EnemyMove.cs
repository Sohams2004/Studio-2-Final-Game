using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float patrolSpeed;

    [SerializeField] public int pointIndex;

    [SerializeField] private Transform[] points;

    [SerializeField] public Rigidbody2D enemyRb;

    private void Start()
    {
    }

    public void EnemyPatrol()
    {
        if (Vector2.Distance(transform.position, points[pointIndex].position) < 0.01f)
        {
            pointIndex += 1;

            if (pointIndex == points.Length)
            {
                pointIndex = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, points[pointIndex].position, patrolSpeed * Time.deltaTime);
    }

    private void Update()
    {
    }
} 
