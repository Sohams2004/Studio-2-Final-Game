using UnityEngine;

public class KnockbackAbility : MonoBehaviour
{
    [SerializeField] GameObject abilityDisplay1;
    [SerializeField] GameObject abilityDisplay2;
    public bool powerupKnockback;
    private void Start()
    {
        powerupKnockback = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player 1")
        {
            abilityDisplay2.SetActive(true);
            /*it will soon stop being activate but set */
            OnPick();

        }
        if (other.tag == "Player 2")
        {
            abilityDisplay1.SetActive(true);
            /*it will soon stop being activate but set */
            OnPick();

        }

    }
    void OnPick()
    {
        powerupKnockback = true;
        gameObject.SetActive(false);

    }
}
