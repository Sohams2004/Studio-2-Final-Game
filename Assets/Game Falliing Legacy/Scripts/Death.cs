using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [SerializeField] Animator animator1;
    [SerializeField] Animator animator2;

    async private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player 1")
        {
            await Task.Delay(300);
            animator2.SetBool("Death", true);
            await Task.Delay(1000);
            Destroy(other.gameObject);
            SceneManager.LoadScene(1);
        }
        if (other.tag == "Player 2")
        {
            await Task.Delay(300);
            animator2.SetBool("Death", true);
            await Task.Delay(1000);
            Destroy(other.gameObject);
            SceneManager.LoadScene(1);
        }
    }
}
