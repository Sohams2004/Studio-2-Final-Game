using UnityEngine;
using UnityEngine.UI;

public class SamuAbility1 : MonoBehaviour
{
    [SerializeField] TestAttack testAttack;
    [SerializeField] TestMovement2D testMovement;
    public bool powerupKnockback;

    [SerializeField] string abilityInput;
    [SerializeField] float abilityTimer, abilityCoolDown;
    [SerializeField] float maxAbilityTime, maxCoolDownTime;
    public bool playeraAbility, timerOn, coolDownTimer;

    [SerializeField] bool abilityActive;

    [SerializeField] Button samuButton;
    private void Start()
    {
        testAttack = GetComponent<TestAttack>();
        testMovement = GetComponent<TestMovement2D>();

    }

    void AbilityActivate()
    {
        if (Input.GetButtonDown(abilityInput) && !coolDownTimer)
        {
            Debug.Log("Ability activated");
            timerOn = true;

            testAttack.enabled = true;
            powerupKnockback = true;
            testAttack.repulseForce += 20;
            testAttack.knocBackCount += 15;
            testMovement.movementSpeed += 2;
            testMovement.jumpForce += 2;
            samuButton.interactable = false;
            abilityActive = false;

        }

        else if (abilityTimer >= maxAbilityTime)
        {
            playeraAbility = false;

            coolDownTimer = true;
            samuButton.interactable = true;
            abilityTimer = 0;

            if (!abilityActive)
            {
                testAttack.repulseForce -= 20;
                testAttack.knocBackCount -= 15;
                testMovement.movementSpeed -= 2;
                testMovement.jumpForce -= 2;
            }
            abilityActive = true;
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
