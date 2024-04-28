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

    [SerializeField] private Transform respawnLocation1;
    [SerializeField] private Transform respawnLocation2;
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    [SerializeField] GameObject player1health1;
    [SerializeField] GameObject player1health2;
    [SerializeField] GameObject player1health3;
    [SerializeField] GameObject player1health4;

    [SerializeField] GameObject player2health1;
    [SerializeField] GameObject player2health2;
    [SerializeField] GameObject player2health3;
    [SerializeField] GameObject player2health4;
    private void Start()
    {
        outOfSight.SetActive(false);
    }
    async private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player 1")
        {
            stillin1 = true;
            await Task.Delay(500);

            if (stillin1)
            {

                animator1.SetTrigger("Death");
                await Task.Delay(1200);

                player1Lives--;
                WinCondition();
                if (player1Lives == 4)
                {
                    player1health4.SetActive(false);
                    player1.transform.position = respawnLocation1.transform.position;
                    Physics2D.SyncTransforms();
                }

                else if (player1Lives == 3)
                {
                    player1health3.SetActive(false);
                    player1.transform.position = respawnLocation1.transform.position;
                    Physics2D.SyncTransforms();
                }
                else if (player1Lives == 2)
                {
                    player1health2.SetActive(false);
                    player1.transform.position = respawnLocation1.transform.position;
                    Physics2D.SyncTransforms();
                }
                if (player1Lives == 1)
                {
                    player1health1.SetActive(false);
                    player1.transform.position = respawnLocation1.transform.position;
                    Physics2D.SyncTransforms();
                }
                else if (player1Lives == 0)
                {

                    kO.Play();
                    Destroy(other.gameObject);
                    outOfSight.SetActive(true);
                    await Task.Delay(2000);
                    SceneManager.LoadScene(1);
                }
            }
            else if (!stillin1)
            {
                stillin1 = false;
                outOfSight.SetActive(false);
                animator1.ResetTrigger("Death");
                await Task.Delay(400);

            }



        if (other.tag == "Player 2")
        {
            stillin2 = true;
            await Task.Delay(500);

            if (stillin2)
            {
                animator2.SetTrigger("Death");
                await Task.Delay(1200);

                player2Lives--;
                WinCondition();

                if (player2Lives == 4)
                {
                    player2health4.SetActive(false);

                    player2.transform.position = respawnLocation2.transform.position;
                    Physics2D.SyncTransforms();
                }

                else if (player2Lives == 3)
                {
                    player2health3.SetActive(false);
                    player2.transform.position = respawnLocation2.transform.position;
                    Physics2D.SyncTransforms();
                }
                else if (player2Lives == 2)
                {
                    player2health2.SetActive(false);
                    player2.transform.position = respawnLocation2.transform.position;
                    Physics2D.SyncTransforms();
                }
                if (player2Lives == 1)
                {
                    player2health1.SetActive(false);
                    player2.transform.position = respawnLocation2.transform.position;
                    Physics2D.SyncTransforms();
                }
                else if (player2Lives == 0)
                {

                    kO.Play();
                    Destroy(other.gameObject);
                    outOfSight.SetActive(true);
                    await Task.Delay(2000);
                    SceneManager.LoadScene(1);
                }
            }
            else if (!stillin2)
            {
                stillin2 = false;
                outOfSight.SetActive(false);
                animator2.ResetTrigger("Death");
                await Task.Delay(400);
            }
        }

    }
    async private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player 1")
        {

            stillin1 = false;
            outOfSight.SetActive(false);
            animator1.ResetTrigger("Death");
            await Task.Delay(400);
        }
        if (other.tag == "Player 2")
        {

            stillin2 = false;
            outOfSight.SetActive(false);
            animator2.ResetTrigger("Death");
            await Task.Delay(400);
        }
    }
}
