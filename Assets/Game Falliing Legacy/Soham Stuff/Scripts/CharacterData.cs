using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterData : ScriptableObject
{
    [SerializeField] public Characters[] data;

    public int CharacterCount => data.Length;

    public Characters GetCharacter(int index) => data[index];
}
