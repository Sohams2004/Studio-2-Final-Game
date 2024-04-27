using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] Camera camera;

    [SerializeField] bool isFiring;

    [SerializeField] GameObject bullet;
    [SerializeField] public GameObject gun;

    [SerializeField] Transform bulletPoint;

    [SerializeField] float timer, fireTimer;

    [SerializeField] TestAttack attack;

    private void Start()
    {
        //camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        isFiring = true;
    }

    /*void MoveMosue()
    {
        Vector3 mousePosition = new Vector3(Input.GetAxis("RightVertical"), Input.GetAxis("RightHorizontal"), 0);
        Vector3 rotation = mousePosition;
        float rotateZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;  //The Mathf.Atan2 returns the angle in radians hence we convert it to degrees by Rad2Deg because Quaternion only accepts angles in degrees
        transform.rotation = Quaternion.Euler(0, 0, rotateZ); 
    }*/

    void Fire()
    {
        if(!isFiring)
        {
            timer += Time.deltaTime;
            if(timer > fireTimer)
            {
                isFiring = true;
                timer = 0;
            }
        }

        if(Input.GetButtonDown(attack.attackInput) && isFiring)
        {
            isFiring = false;
            Instantiate(bullet, bulletPoint.position, Quaternion.identity);
        }
    }

    private void Update()
    {
       // MoveMosue();
        Fire();
    }
}
