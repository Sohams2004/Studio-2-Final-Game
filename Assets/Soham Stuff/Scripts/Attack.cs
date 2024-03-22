using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    void PlayerAttack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Attacked");

        }
    }

    private void Update()
    {
        PlayerAttack();
    }
}
