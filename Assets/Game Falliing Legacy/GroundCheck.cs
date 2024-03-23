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

    private void OnCollisionEnter2D(Collision2D other)
    {
        stateCount++;
    }

    private void OnCollisionExit2D(Collision2D other)
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
