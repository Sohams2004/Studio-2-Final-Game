using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerUIScript : MonoBehaviour
{
    //Script to be attached to the CANVAS of scene
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float remainingTime;
    [SerializeField] Animator animator1;
    [SerializeField] Animator animator2;

    async void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (remainingTime == 0)
        {
            animator1.SetBool("Death", true);
            animator2.SetBool("Death", true);
            await Task.Delay(1000);
            SceneManager.LoadScene(1);
        }
    }
}
