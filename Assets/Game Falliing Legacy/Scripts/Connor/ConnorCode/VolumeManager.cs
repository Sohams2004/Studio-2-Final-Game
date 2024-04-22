using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class volumeslider : MonoBehaviour
{
    public Slider VolumeManager;
    
    void Start()
    {

        if (!PlayerPrefs.HasKey("MenuMusic"))
        {
            PlayerPrefs.SetFloat("MenuMusic", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    
    void Update()
    {

    }
    public void ChangeVolume()
    {
        AudioListener.volume = VolumeManager.value;
        Save();
    }
    public void Save()
    {
        PlayerPrefs.SetFloat("MenuMusic", VolumeManager.value);
    }
    public void Load()
    {
        VolumeManager.value = PlayerPrefs.GetFloat("MenuMusic");
        AudioListener.volume = VolumeManager.value;
    }
}