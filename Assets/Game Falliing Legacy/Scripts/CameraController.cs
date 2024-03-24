using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform[] players;
    public float smoothTime = 0.3f;
    public Vector3 offset;

    public GameObject[] boundaryObjects;
    private Bounds boundaries;

    private Vector3 velocity;

    void Start()
    {
        CalculateBoundaries();
    }

    void LateUpdate()
    {
        if (players.Length == 0)
            return;

        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;

        // Check if the camera is within the boundaries
        newPosition = ClampToBounds(newPosition);

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    Vector3 GetCenterPoint()
    {
        if (players.Length == 1)
            return players[0].position;

        Bounds bounds = new Bounds(players[0].position, Vector3.zero);
        for (int i = 0; i < players.Length; i++)
        {
            bounds.Encapsulate(players[i].position);
        }
        return bounds.center;
    }

    Vector3 ClampToBounds(Vector3 position)
    {
        // Clamp camera position within the boundaries
        float newX = Mathf.Clamp(position.x, boundaries.min.x, boundaries.max.x);
        float newY = Mathf.Clamp(position.y, boundaries.min.y, boundaries.max.y);
        float newZ = position.z; // You may want to adjust this depending on your game
        return new Vector3(newX, newY, newZ);
    }

    void CalculateBoundaries()
    {
        // Calculate boundaries based on boundary objects
        boundaries = new Bounds(boundaryObjects[0].transform.position, Vector3.zero);
        foreach (var boundaryObject in boundaryObjects)
        {
            boundaries.Encapsulate(boundaryObject.GetComponent<Collider>().bounds);
        }
    }
}

