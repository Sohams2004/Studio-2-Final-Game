using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public GameObject optionPrefab;

    public Transform previousCharacter, selectedCharacter;

    private void Start()
    {
        foreach(Characters characters in CharacterManager.instance.characters)
        {
            GameObject option = Instantiate(optionPrefab, transform);
            Button button = option.GetComponent<Button>();

            button.onClick.AddListener(() =>
            {
                CharacterManager.instance.SetCharacter(characters);
                if (selectedCharacter != null)
                {
                    previousCharacter = selectedCharacter;
                }

                selectedCharacter = option.transform;
            });
        }
    }
}