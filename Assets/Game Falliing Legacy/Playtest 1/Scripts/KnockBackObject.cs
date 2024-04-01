using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class KnockBackObject : MonoBehaviour
{
    TestAttack testAttack;
    public void KnockBack(Vector2 knockBackDirection)
    {
        for (int i = 0; i < testAttack.target.Length; i++)
        {
            testAttack.target[i].attachedRigidbody.velocity = -knockBackDirection.normalized * testAttack.repulseForce;
        }
    }
}
