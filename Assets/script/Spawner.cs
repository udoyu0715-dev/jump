using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Ground Obstacles (Multiple)")]
    public GameObject[] groundObstacles;

    [Header("Air Obstacle")]
    public GameObject airObstacle;

    [Header("Spawn Settings")]
    public float spawnRate = 2f;
    public float minSpawnRate = 0.7f;
    public float spawnAcceleration = 0.05f;

    private float timer;

    [Header("Spawn Heights")]
    public float groundY = -3.5f;
    public float airY = 1.5f;

    [Header("Ground Spawn Chance")]
    [Range(0f, 1f)]
    public float groundChance = 0.7f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnObstacle();

            timer = 0f;

            IncreaseDifficulty();
        }
    }

    void SpawnObstacle()
    {
        float randomValue = Random.value;

        // Ground obstacle (random pick)
        if (randomValue < groundChance)
        {
            int index = Random.Range(0, groundObstacles.Length);

            Instantiate(
                groundObstacles[index],
                new Vector3(transform.position.x, groundY, 0f),
                Quaternion.identity
            );
        }
        // Air obstacle
        else
        {
            Instantiate(
                airObstacle,
                new Vector3(transform.position.x, airY, 0f),
                Quaternion.identity
            );
        }
    }

    void IncreaseDifficulty()
    {
        spawnRate -= spawnAcceleration;

        if (spawnRate < minSpawnRate)
        {
            spawnRate = minSpawnRate;
        }
    }
}