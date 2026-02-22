using UnityEngine;
using System.Collections;

public class PickupSpawnerScript : MonoBehaviour
{
    public GameObject pickupPrefab;
    private GameObject[] spawnPointList;
    [Header("Pickups")]
    public int numberOfPickups = 3;

    void Awake()
    {
        // get the tagged spawn points in scene
        spawnPointList = GameObject.FindGameObjectsWithTag("SpawnPoint");
        // array list for used spawn points to avoid duplicates
        ArrayList usedIndexes = new ArrayList();
        for (int i = 0; i < numberOfPickups; i++)
        {
            int randomIndex;
            // loop until unused spawnpoint is found
            do
            {
                // choose a random index from the list of spawn points
                randomIndex = Random.Range(0, spawnPointList.Length);
            } while (usedIndexes.Contains(randomIndex));
            usedIndexes.Add(randomIndex);
            GameObject spawnPoint = spawnPointList[randomIndex];
            // spawn pickup at the random spawn point
            SpawnPickup(spawnPoint);
        }
    }

    public void SpawnPickup(GameObject spawnPoint)
    {
        // spawn pickup
        Instantiate(pickupPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
}