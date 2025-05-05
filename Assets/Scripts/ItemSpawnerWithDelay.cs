using UnityEngine;

public class ItemSpawnerWithDelay : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject itemPrefab;
    public float delayBeforeSpawn = 5f;
    
    private GameObject spawnedItem;
    
    void Start()
    {
        Invoke(nameof(SpawnItem), delayBeforeSpawn);
    }

    void SpawnItem()
    {
        int index = Random.Range(0, spawnPoints.Length);
        spawnedItem = Instantiate(itemPrefab, spawnPoints[index].position, spawnPoints[index].rotation);
    }
}
