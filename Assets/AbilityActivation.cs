using UnityEngine;

public class AbilityActivation : MonoBehaviour
{
    private KnockbackAbility knockbackAbility;
    private TestAttack testAttack;
    [SerializeField] float amp = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (knockbackAbility.powerupKnockback /* && input. whatever*/)
        {
            KnockbackActivation();
            /*Remove the ability */
        }
    }
    void KnockbackActivation()
    {
        testAttack.repulseForce += amp;
    }
}
