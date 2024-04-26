using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneTransfer : MonoBehaviour
{
    public string sceneToLoad; 

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("PlayerTut"))
        {
            
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}