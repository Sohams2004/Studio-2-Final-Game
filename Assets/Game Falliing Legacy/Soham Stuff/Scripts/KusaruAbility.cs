using UnityEngine;
using UnityEngine.UI;

public class KusaruAbility : MonoBehaviour
{
    [SerializeField] string abilityInput;
    [SerializeField] float abilityTimer, abilityCoolDown;
    [SerializeField] float maxAbilityTime, maxCoolDownTime;
    public bool playeraAbility, timerOn, coolDownTimer;

    [SerializeField] TestAttack testAttack;
    [SerializeField] Shoot shoot;

    [SerializeField] Button KusaruButton;
    private void Start()
    {
        testAttack = GetComponent<TestAttack>();
        shoot.gun.SetActive(false);
    }

    void AbilityActivate()
    {
        if (Input.GetButtonDown(abilityInput) && !coolDownTimer)
        {
            Debug.Log("Ability activated");
            timerOn = true;
            playeraAbility = true;
            testAttack.enabled = false;
            shoot.enabled = true;
            shoot.gun.SetActive(true);
            KusaruButton.interactable = false;
        }

        else if (abilityTimer >= maxAbilityTime)
        {
            playeraAbility = false;
            testAttack.enabled = true;
            shoot.enabled = false;
            coolDownTimer = true;
            shoot.gun.SetActive(false);
            KusaruButton.interactable = true;
            abilityTimer = 0;
        }
    }

    private void Update()
    {
        AbilityActivate();

        if (timerOn)
        {
            abilityTimer += Time.deltaTime;
        }

        else
        {
            abilityTimer = 0;
        }

        if (coolDownTimer)
        {
            abilityCoolDown += Time.deltaTime;
        }

        else if (abilityCoolDown >= maxCoolDownTime)
        {
            abilityCoolDown = 0;
            coolDownTimer = false;
        }
    }
}
