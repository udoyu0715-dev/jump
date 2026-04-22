using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject groundObstacle;
    public GameObject airObstacle;

    public float spawnRate = 2f;
    public float startDelay = 1f;

    [Header("Spawn Heights")]
    public float groundY = -3.5f;
    public float airY = 1.5f;

    [Header("Ground Spawn Chance (0-1)")]
    public float groundChance = 0.7f; // 70% ground, 30% air

    void Start()
    {
        InvokeRepeating(nameof(Spawn), startDelay, spawnRate);
    }

    void Spawn()
    {
        float randomValue = Random.value;

        GameObject obj;

        if (randomValue < groundChance)
        {
            obj = Instantiate(groundObstacle, transform.position, Quaternion.identity);
            obj.transform.position = new Vector3(transform.position.x, groundY, 0f);
        }
        else
        {
            obj = Instantiate(airObstacle, transform.position, Quaternion.identity);
            obj.transform.position = new Vector3(transform.position.x, airY, 0f);
        }
    }
}