using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MatchManager
{
    [SerializeField] AudioSource kO;
    [SerializeField] Animator animator1;
    [SerializeField] Animator animator2;
    [SerializeField] GameObject outOfSight;
    bool stillin1 = false;
    bool stillin2 = false;
    public int player1Lives = 5;
    public int player2Lives = 5;
    private void Start()
    {
        outOfSight.SetActive(false);
    }
    async private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player 1")
        {
            stillin1 = true;
            await Task.Delay(500);

            if (stillin1)
            {
                kO.Play();
                outOfSight.SetActive(true);

                animator1.SetBool("Death", true);
                await Task.Delay(1200);
                Destroy(other.gameObject);
                player1Lives--;
                WinCondition();
                SceneManager.LoadScene(1);
            }
            else if (!stillin1)
            {
                stillin1 = false;
                outOfSight.SetActive(false);

            }


        }
        if (other.tag == "Player 2")
        {
            stillin2 = true;
            await Task.Delay(500);

            if (stillin2)
            {
                kO.Play();
                outOfSight.SetActive(true);

                animator2.SetBool("Death", true);
                await Task.Delay(1200);
                Destroy(other.gameObject);
                player2Lives--;
                WinCondition();
                SceneManager.LoadScene(1);
            }
            else if (!stillin2)
            {
                stillin2 = false;
                outOfSight.SetActive(false);

            }
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player 1")
        {

            stillin1 = false;
            outOfSight.SetActive(false);

        }
        if (other.tag == "Player 2")
        {

            stillin2 = false;
            outOfSight.SetActive(false);

        }
    }
}
