using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [SerializeField] Animator animator1;
    [SerializeField] Animator animator2;
    bool stillin1 = false;
    bool stillin2 = false;

    async private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player 1")
        {
            stillin1 = true;
            await Task.Delay(500);

            if (stillin1)
            {
                animator1.SetBool("Death", true);
                await Task.Delay(1000);
                Destroy(other.gameObject);
                SceneManager.LoadScene(1);
            }


        }
        if (other.tag == "Player 2")
        {
            stillin2 = true;
            await Task.Delay(500);

            if (stillin2)
            {
                animator2.SetBool("Death", true);
                await Task.Delay(1000);
                Destroy(other.gameObject);
                SceneManager.LoadScene(1);
            }

        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player 1")
        {

            stillin1 = false;

        }
        if (other.tag == "Player 2")
        {

            stillin2 = false;
        }
    }
}
