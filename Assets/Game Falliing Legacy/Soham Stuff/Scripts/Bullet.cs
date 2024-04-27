using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D bulletRb;
    [SerializeField] float BulletSpeed, bulletTimer, destroyBulletAfter;
    [SerializeField] Camera camera;
    GameObject opponent;
    Vector3 mousePosition, bulletDirection, rotation;

    private void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
        opponent = GameObject.FindWithTag("Player 2");

        /*camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        mousePosition = new Vector3(Input.GetAxis("RightVertical"), Input.GetAxis("RightHorizontal"), 0);
        bulletDirection = mousePosition - transform.position;
        rotation = transform.position - mousePosition;*/

        MoveBulluet();
    }

    void MoveBulluet()
    {
        //bulletRb.velocity = new Vector2(bulletDirection.x, bulletDirection.y).normalized * BulletSpeed;

        Vector2 attractBullet = (opponent.transform.position - transform.position).normalized;
        bulletRb.AddForce(attractBullet * BulletSpeed * 100);
    }

    void DestroyBullet()
    {
        bulletTimer += Time.deltaTime;
        if (bulletTimer > destroyBulletAfter)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        DestroyBullet();
    }
}
