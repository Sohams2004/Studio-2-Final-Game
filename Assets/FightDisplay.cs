using System.Threading.Tasks;
using UnityEngine;

public class FightDisplay : MonoBehaviour
{
    [SerializeField] GameObject fightText;
    // Start is called before the first frame update
    void Start()
    {
        Fight();
    }

    async void Fight()
    {
        fightText.SetActive(false);
        await Task.Delay(700);
        fightText.SetActive(true);
        await Task.Delay(500);
        fightText.SetActive(false);
    }
}
