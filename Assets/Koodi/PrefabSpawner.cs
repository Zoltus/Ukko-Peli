using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Autopeli
{

    public class PrefabSpawner : MonoBehaviour
    {
        // The prefabs to be spawned
        public GameObject rockPrefab;
        public GameObject gasCanPrefab;

        // The y-coordinates where the prefabs can be spawned
        public float[] spawnYCoordinates = { -1.06f, -2.81f, -4.31f };

        // The x-coordinate where the prefabs will be spawned
        public float spawnXCoordinate = 0f;

        // Keep track of which lanes have been used
        private List<int> usedLanes = new List<int>();

        // Start is called before the first frame update
        private void Start()
        {
            // Spawn the prefabs repeatedly, every 7 seconds
            InvokeRepeating("SpawnPrefabs", 0f, 7f);
            spawnXCoordinate = transform.position.x;
        }

        // Spawn three prefabs at a time, with a random gas canister and rocks on the other two lanes
        private void SpawnPrefabs()
        {
            // Shuffle the y-coordinate array to randomize the order in which the prefabs are spawned on the y-axis
            for (int i = 0; i < spawnYCoordinates.Length; i++)
            {
                float temp = spawnYCoordinates[i];
                int randomIndex = Random.Range(i, spawnYCoordinates.Length);
                spawnYCoordinates[i] = spawnYCoordinates[randomIndex];
                spawnYCoordinates[randomIndex] = temp;
            }

            // Spawn 3 prefabs, with one of them being a gas canister and the other two being rocks
            for (int i = 0; i < 3; i++)
            {
                float y = spawnYCoordinates[i];
                GameObject prefabToSpawn = rockPrefab;

                // If this is the second prefab to be spawned, choose a random y coordinate for the gas canister
                if (i == 1)
                {
                    y = spawnYCoordinates[Random.Range(0, spawnYCoordinates.Length)];
                    prefabToSpawn = gasCanPrefab;
                }

                // Check which lanes have been used already and choose an unused lane to spawn the prefab
                int laneToUse = -1;
                for (int j = 0; j < spawnYCoordinates.Length; j++)
                {
                    if (!usedLanes.Contains(j))
                    {
                        laneToUse = j;
                        usedLanes.Add(j);
                        break;
                    }
                }

                // Spawn the prefab at the chosen position
                GameObject spawnedPrefab = Instantiate(prefabToSpawn, new Vector3(spawnXCoordinate, spawnYCoordinates[laneToUse], 0), Quaternion.identity);

                // Destroy the prefab after 9 seconds
                Destroy(spawnedPrefab, 9f);
            }

            // Reset the list of used lanes
            usedLanes.Clear();
        }
    }
}