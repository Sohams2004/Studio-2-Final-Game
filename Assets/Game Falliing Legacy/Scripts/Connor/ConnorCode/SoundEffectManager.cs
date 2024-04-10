using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    public AudioClip[] audioClips; // Array to hold multiple audio clips
    private AudioSource audioSource; // AudioSource component reference

    void Start()
    {
        // Check if AudioSource component is not assigned
        if (GetComponent<AudioSource>() == null)
        {
            // Add AudioSource component if not already attached
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            // Get the AudioSource component attached to the GameObject
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        // Check if any desired keyboard buttons are pressed, for example 'A', 'S', 'D', 'F', 'G' keys
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayAudioClip(0); // Play the first audio clip when 'A' is pressed
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            PlayAudioClip(1); // Play the second audio clip when 'S' is pressed
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            PlayAudioClip(2); // Play the third audio clip when 'D' is pressed
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            PlayAudioClip(3); // Play the fourth audio clip when 'F' is pressed
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            PlayAudioClip(4); // Play the fifth audio clip when 'G' is pressed
        }
    }

    void PlayAudioClip(int index)
    {
        // Check if the index is within the bounds of the audioClips array
        if (index >= 0 && index < audioClips.Length)
        {
            // Check if audio source component is not null
            if (audioSource != null)
            {
                // Set the clip to the audio source
                audioSource.clip = audioClips[index];
                // Play the audio clip
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