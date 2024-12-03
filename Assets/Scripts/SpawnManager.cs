using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] itemPrefab; // Array to store the item prefabs
    public float minTime = 1f;      // Minimum wait time between spawns
    public float maxTime = 2f;      // Maximum wait time between spawns

    // Define the range of random spawn positions in the X, Y, Z directions
    public Vector3 spawnCenter;     // The center point of the spawn area
    public Vector3 spawnRange;      // The size of the spawn area (half-width, half-height, half-depth)

    void Start()
    {
        // Start spawning items immediately
        StartCoroutine(SpawnCoroutine(0));
    }

    // Coroutine to spawn items at random intervals
    IEnumerator SpawnCoroutine(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        // Check if there are any item prefabs to spawn
        if (itemPrefab.Length > 0)
        {
            // Randomize the spawn position within the defined bounds
            Vector3 randomPosition = new Vector3(
                Random.Range(spawnCenter.x - spawnRange.x, spawnCenter.x + spawnRange.x),
                Random.Range(spawnCenter.y - spawnRange.y, spawnCenter.y + spawnRange.y),
                Random.Range(spawnCenter.z - spawnRange.z, spawnCenter.z + spawnRange.z)
            );

            // Instantiate a random item at the calculated position with no rotation
            Instantiate(itemPrefab[Random.Range(0, itemPrefab.Length)], randomPosition, Quaternion.identity);
        }

        // Schedule the next item spawn with a random wait time
        StartCoroutine(SpawnCoroutine(Random.Range(minTime, maxTime)));
    }

    // Optional: Use this to visualize the spawn area in the editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(spawnCenter, spawnRange * 2); // Draw a wireframe cube representing the spawn area
    }
}
