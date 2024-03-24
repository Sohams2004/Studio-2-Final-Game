using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject SpawnPrefab;
    public float delay = 30f;

    private float timer = 0f;
    private bool hasSpawned = false;

    void Update()
    {

        timer += Time.deltaTime;


        if (timer >= delay && !hasSpawned)
        {
            SpawningPrefab();
            hasSpawned = true;
        }
    }

    void SpawningPrefab()
    {

        Instantiate(SpawnPrefab, transform.position, Quaternion.identity);
    }
}
