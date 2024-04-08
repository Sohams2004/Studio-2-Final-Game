using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBuff : MonoBehaviour
{
    public float speedIncreaseAmount = 5f;
    public float jumpIncreaseAmount = 5f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterController characterController = other.GetComponent<CharacterController>();

           
            characterController.Move(Vector3.forward * speedIncreaseAmount * Time.deltaTime);

           
            characterController.Move(Vector3.up * jumpIncreaseAmount * Time.deltaTime);

            
            gameObject.SetActive(false);
        }
    }
}