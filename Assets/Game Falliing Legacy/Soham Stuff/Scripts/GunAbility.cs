using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAbility : MonoBehaviour
{
    [SerializeField] bool isGunActive;
    [SerializeField] float abilityTimer;
    [SerializeField] float maxTime;

    [SerializeField] KusaruAbility kusaruAbility;

   
    private void ActivateAbility()
    {
        if (kusaruAbility.playeraAbility)
        {
            isGunActive = true;
            abilityTimer += Time.deltaTime;
        }
    }

    void Gun()
    {
        if (abilityTimer >= maxTime && isGunActive)
        {
            isGunActive = false;
        }
    }

    private void Update()
    {
        Gun();
        ActivateAbility();
    }
}
