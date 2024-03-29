using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{

    async private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            await Task.Delay(300);

            Destroy(other.gameObject);

            SceneManager.LoadScene(1);
        }

    }
}
