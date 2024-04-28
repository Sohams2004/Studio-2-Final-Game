using System.Threading.Tasks;
using UnityEngine;

public class Player1Death : MatchManager
{
    [SerializeField] AudioSource kO;
    [SerializeField] Animator animator1;
    [SerializeField] GameObject outOfSight;
    bool stillin1 = false;

    public int player1Lives = 5;

    [SerializeField] private Transform respawnLocation1;

    [SerializeField] private GameObject player1;

    private TestAttack attack;

    [SerializeField] GameObject player1health1;
    [SerializeField] GameObject player1health2;
    [SerializeField] GameObject player1health3;
    [SerializeField] GameObject player1health4;
    void Start()
    {
        outOfSight.SetActive(false);
    }
    async private void OnTriggerEnter2D(Collider2D other)
    {
        // Update is called once per frame
        if (other.tag == "DangerZone")
        {
            stillin1 = true;
            await Task.Delay(300);

            if (stillin1)
            {

                animator1.SetTrigger("Death");
                await Task.Delay(1200);

                player1Lives--;

                if (player1Lives == 4)
                {
                    player1health4.SetActive(false);
                    player1.transform.position = respawnLocation1.transform.position;
                    Physics2D.SyncTransforms();
                    attack.knocBackCount = 0;
                }

                else if (player1Lives == 3)
                {
                    player1health3.SetActive(false);
                    player1.transform.position = respawnLocation1.transform.position;
                    Physics2D.SyncTransforms();
                    attack.knocBackCount = 0;
                }
                else if (player1Lives == 2)
                {
                    player1health2.SetActive(false);
                    player1.transform.position = respawnLocation1.transform.position;
                    Physics2D.SyncTransforms();
                    attack.knocBackCount = 0;
                }
                if (player1Lives == 1)
                {
                    player1health1.SetActive(false);
                    player1.transform.position = respawnLocation1.transform.position;
                    Physics2D.SyncTransforms();
                    attack.knocBackCount = 0;
                }
                else if (player1Lives == 0)
                {

                    kO.Play();
                    outOfSight.SetActive(true);
                    await Task.Delay(2000);
                    p2WinUI.SetActive(true);
                    outOfSight.SetActive(false);
                    Time.timeScale = 0;
                    Destroy(other.gameObject);

                }
            }
            else if (!stillin1)
            {
                stillin1 = false;
                outOfSight.SetActive(false);
                animator1.ResetTrigger("Death");
                await Task.Delay(400);

            }


        }
    }
    async private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "DangerZone")
        {

            stillin1 = false;
            outOfSight.SetActive(false);
            animator1.ResetTrigger("Death");
            await Task.Delay(400);
        }
    }
}
