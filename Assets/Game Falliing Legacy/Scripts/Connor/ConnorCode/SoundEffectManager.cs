using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    public AudioClip[] audioClips; 
    private AudioSource audioSource; 

    void Start()
    {
        
        if (GetComponent<AudioSource>() == null)
        {
           
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayAudioClip(0);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            PlayAudioClip(1); 
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            PlayAudioClip(2); 
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            PlayAudioClip(3); 
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            PlayAudioClip(4); 
        }
    }

    void PlayAudioClip(int index)
    {
        
        if (index >= 0 && index < audioClips.Length)
        {
           
            if (audioSource != null)
            {
               
                audioSource.clip = audioClips[index];
                
                audioSource.Play();
            }
            else
            {
                Debug.LogWarning("AudioSource component not found!");
            }
        }
        else
        {
            Debug.LogWarning("Invalid audio clip index!");
        }
    }
}