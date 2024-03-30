using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCrouch : MonoBehaviour
{
    public string crouchInput;
    private Attack attack;
    private bool block = false;
    private void Start()
    {
        attack = GetComponent<Attack>();
    }
  
    
}
