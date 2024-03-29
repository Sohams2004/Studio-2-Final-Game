using UnityEngine;

interface IPushable
{
    void Push(Vector2 direction);
}

public class Movement :MonoBehaviour, IPushable
{
    int numberOfHits = 0;



    public void Push(Vector2 direction)
    {
        numberOfHits++;
        rb.AddForce(numberOfHits * direction);
    }
}
