using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAbility : MonoBehaviour
{
    [SerializeField] GameObject gun;
    [SerializeField] bool isGunActive;
    [SerializeField] float abilityTimer;
    [SerializeField] float maxTime;

    [SerializeField] Attack attack;

    private void Awake()
    {
        gun = GameObject.FindWithTag("Gun");
        attack = GetComponent<Attack>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gun Ability"))
        {
            other.enabled = false;
            isGunActive = true;
            attack.enabled = false;
            abilityTimer += Time.deltaTime;
        }
    }

    void Gun()
    {
        if (abilityTimer >= maxTime && isGunActive)
        {
            isGunActive = false;
            attack.enabled = true;
        }
    }

    private void Update()
    {
        Gun();
    }
}
