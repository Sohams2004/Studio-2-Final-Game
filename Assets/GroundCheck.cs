using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] int stateCount = 0;

    [SerializeField] float timeOnGround;

    private void OnEnable()
    {
        stateCount = 0;
    }

    public bool State()
    {
        if (timeOnGround > 0)
            return false;
        return stateCount > 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        stateCount++;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        stateCount--;
    }

    void Update()
    {
        timeOnGround -= Time.deltaTime;
    }

    public void Disable(float duration)
    {
        timeOnGround = duration;
    }
}
