using System.Collections;
using UnityEngine;

public class FighterCamController : MonoBehaviour
{
    [SerializeField] private Transform player1, player2;
    [SerializeField] private float minZoom = 5f;
    [SerializeField] private float maxZoom = 15f;
    [SerializeField] private float zoomSpeed = 5f;
    [SerializeField] private float followSpeed = 5f;
    [SerializeField] private GameObject border;
    private bool isOutOfBounds = false;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();

        player1 = GameObject.FindWithTag("Player1").GetComponent<Transform>();
        player2 = GameObject.FindWithTag("Player2").GetComponent<Transform>();
    }

    void Update()
    {
        if (!isOutOfBounds)
        {
            Vector3 centerPoint = (player1.position + player2.position) / 2f;
            centerPoint.z = transform.position.z;

            transform.position = Vector3.Lerp(transform.position, centerPoint, followSpeed * Time.deltaTime);

            float distance = Vector3.Distance(player1.position, player2.position);
            float targetZoom = Mathf.Lerp(minZoom, maxZoom, distance / 10f);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, zoomSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == border)
        {
            isOutOfBounds = true;
            Transform player = other.gameObject.CompareTag("Player1") ? player1 : player2;
            StartCoroutine(FocusOnPlayer(player));
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == border)
        {
            isOutOfBounds = false;
        }
    }

    IEnumerator FocusOnPlayer(Transform target)
    {
        while (Vector3.Distance(transform.position, target.position) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, followSpeed * Time.deltaTime);
            yield return null;
        }
    }
}