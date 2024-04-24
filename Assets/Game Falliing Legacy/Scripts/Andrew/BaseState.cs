using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    public abstract void EnterState(AttackStateManager context);
    public abstract void UpdateState(AttackStateManager context);
    public abstract void OnCollisionEnter2D(AttackStateManager context, Collision2D collision);
}
