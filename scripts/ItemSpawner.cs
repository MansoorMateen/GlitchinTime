using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itemPrefabs;    // Array of item prefabs to spawn
    public float initialSpawnRate = 2f; // Initial rate at which items are spawned
    public float spawnRateIncreaseInterval = 10f; // Time interval to increase spawn rate
    public float spawnRateMultiplier = 0.9f; // Multiplier to decrease spawn rate (increase speed)
    public float itemLifeTime = 5f;     // Time before the item is destroyed

    private Camera mainCamera;
    private float spawnTimer;
    private float elapsedTime;
    private float currentSpawnRate;

    private void Start()
    {
        mainCamera = Camera.main;
        currentSpawnRate = initialSpawnRate;
        spawnTimer = 0f;
        elapsedTime = 0f;
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        elapsedTime += Time.deltaTime;

        if (spawnTimer >= currentSpawnRate)
        {
            SpawnItem();
            spawnTimer = 0f;
        }

        if (elapsedTime >= spawnRateIncreaseInterval)
        {
            IncreaseSpawnRate();
            elapsedTime = 0f;
        }
    }

    private void SpawnItem()
    {
        // Choose a random item prefab
        GameObject itemPrefab = itemPrefabs[Random.Range(0, itemPrefabs.Length)];

        // Get random position on the border
        Vector3 spawnPosition = GetRandomBorderPosition();

        // Instantiate the item at the spawn position
        GameObject item = Instantiate(itemPrefab, spawnPosition, Quaternion.identity);

        // Destroy the item after a certain time to prevent overwhelming the player
        Destroy(item, itemLifeTime);
    }

    private Vector3 GetRandomBorderPosition()
    {
        float x, y;
        int side = Random.Range(0, 4);

        switch (side)
        {
            case 0: // Top
                x = Random.Range(0, Screen.width);
                y = Screen.height;
                break;
            case 1: // Bottom
                x = Random.Range(0, Screen.width);
                y = 0;
                break;
            case 2: // Left
                x = 0;
                y = Random.Range(0, Screen.height);
                break;
            case 3: // Right
                x = Screen.width;
                y = Random.Range(0, Screen.height);
                break;
            default:
                x = 0;
                y = 0;
                break;
        }

        // Convert screen position to world position
        Vector3 screenPosition = new Vector3(x, y, mainCamera.nearClipPlane);
        return mainCamera.ScreenToWorldPoint(screenPosition);
    }

    private void IncreaseSpawnRate()
    {
        currentSpawnRate *= spawnRateMultiplier;
    }
}
