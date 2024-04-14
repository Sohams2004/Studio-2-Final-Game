using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance;

    public Characters[] characters;

    public Characters currentCharacter;

    private void Awake()
    {
        if (instance is null)
        {
            instance = this;
        }
        
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (characters.Length > 0 && currentCharacter is null)
        {
            currentCharacter = characters[0];
        }
    }

    public void SetCharacter(Characters characters)
    {
        currentCharacter = characters;
    }
}
