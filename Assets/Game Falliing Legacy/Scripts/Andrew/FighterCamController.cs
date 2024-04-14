using UnityEngine;

public class FighterCamController : MonoBehaviour
{
    [SerializeField] private Transform player1, player2;
    [SerializeField] private float minZoom = 5f;
    [SerializeField] private float maxZoom = 15f;
    [SerializeField] private float zoomSpeed = 5f;
    [SerializeField] private float followSpeed = 5f;
    Vector3 centerPoint;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();

        player1 = GameObject.FindWithTag("Player 1").GetComponent<Transform>();

        player2 = GameObject.FindWithTag("Player 2").GetComponent<Transform>();

        centerPoint = (player1.position + player2.position) / 2f;
    }

    void LateUpdate()
    {
            centerPoint.z = transform.position.z;

            transform.position = Vector3.Lerp(transform.position, centerPoint, followSpeed * Time.deltaTime);

            float distance = Vector3.Distance(player1.position, player2.position);

            float targetZoom = Mathf.Lerp(minZoom, maxZoom, distance / 10f);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, zoomSpeed * Time.deltaTime);
    }
}
