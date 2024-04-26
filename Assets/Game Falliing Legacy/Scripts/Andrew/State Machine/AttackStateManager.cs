using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStateManager : MonoBehaviour
{
    BaseState currentState;
    public DefaultAttackState daState = new DefaultAttackState();
    public ExtendedSwordState esState = new ExtendedSwordState();
    
    public void Start()
    {
        currentState = daState;
        currentState.EnterState(this);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.OnCollisionEnter2D(this, collision);
    }

    public void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(BaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
