using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] characterButtons;
    private int[] selectedCharacters = new int[2];
    private int characterCount = 0;


    public Button button;

    void Start()
    {

        button.onClick.AddListener(ConfirmSelection);
    }

    private void ConfirmSelection()
    {
        if (characterCount < 2)
        {
            Debug.Log("Please select 2 characters first.");
            return;
        }



        PlayerPrefs.SetInt("Character1Index", selectedCharacters[0]);
        PlayerPrefs.SetInt("Character2Index", selectedCharacters[1]);

        SceneManager.LoadScene("GameplayScene");
    }

    public void SelectCharacter(int characterIndex)
    {
        selectedCharacters[characterCount] = characterIndex;
        characterCount++;
        button.interactable = false;
    }


}