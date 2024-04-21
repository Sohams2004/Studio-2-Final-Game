using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D bulletRb;
    [SerializeField] float BulletSpeed, bulletTimer, destroyBulletAfter;
    [SerializeField] Camera camera;
    Vector3 mousePosition, bulletDirection, rotation;

    private void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
        camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        bulletDirection = mousePosition - transform.position;
        rotation = transform.position - mousePosition;

        MoveBulluet();
    }

    void MoveBulluet()
    {
        bulletRb.velocity = new Vector2(bulletDirection.x, bulletDirection.y).normalized * BulletSpeed;
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
