using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] List<GameObject> abilities = new List<GameObject>();
    public float delay = 5f;

    private float timer = 0f;
    private bool hasSpawned = false;

    void Update()
    {
        timer += Time.deltaTime;


        if (timer >= delay)
        {
            SpawningPrefab();
        }
    }

    void SpawningPrefab()
    {
        int randomSpawnPoint = Random.Range(0, spawnPoints.Count);
        int randomAbility = Random.Range(0, abilities.Count);

        Transform spawnLocation = spawnPoints[randomSpawnPoint];
        GameObject spawnAbility = abilities[randomAbility];

        Instantiate(spawnAbility, spawnLocation.position, Quaternion.identity);
    }
}
