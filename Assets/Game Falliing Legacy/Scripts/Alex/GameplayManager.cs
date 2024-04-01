using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public GameObject[] characterPrefabs; // Array of character prefabs
    public Transform[] spawnPoints; // Array of spawn points for characters


    void Start()
    {
        // Load selected characters and map based on PlayerPrefs or GameManager data
        int character1Index = PlayerPrefs.GetInt("Character1Index");
        int character2Index = PlayerPrefs.GetInt("Character2Index");
        int mapIndex = PlayerPrefs.GetInt("MapIndex");

        // Instantiate characters at spawn points
        InstantiateCharacter(character1Index, spawnPoints[0]);
        InstantiateCharacter(character2Index, spawnPoints[1]);


    }

    private void InstantiateCharacter(int characterIndex, Transform spawnPoint)
    {
        if (characterIndex >= 0 && characterIndex < characterPrefabs.Length)
        {
            GameObject characterPrefab = characterPrefabs[characterIndex];

            Instantiate(characterPrefab, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Invalid character index: " + characterIndex);
        }
    }


}