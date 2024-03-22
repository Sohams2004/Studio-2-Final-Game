using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterCamController : MonoBehaviour
{
    [SerializeField] private Transform player1, player2;
    [SerializeField] private float minZoom = 5f;
    [SerializeField] private float maxZoom = 15f;
    [SerializeField] private float zoomSpeed = 5f;
    [SerializeField] private float followSpeed = 5f;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        Vector3 centerPoint = (player1.position + player2.position) / 2f;

        transform.position = Vector3.Lerp(transform.position, centerPoint, followSpeed * Time.deltaTime);

        float distance = Vector3.Distance(player1.position, player2.position);

        float targetZoom = Mathf.Lerp(minZoom, maxZoom, distance / 10f);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, zoomSpeed * Time.deltaTime);
    }
}
