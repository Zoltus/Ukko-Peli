using System.Collections.Generic;
using UnityEngine;

namespace Autopeli {
    public class Spawner : MonoBehaviour {
        private Vector2[] spawnPoints = new Vector2[3];
        public float spawnerGap = 1.5f;
        public float prefabSpeed = 2.63f;

        public GameObject rockPrefab;
        public GameObject canisterPrefab;

        // Start is called before the first frame update
        void Start() {
        Application.targetFrameRate = 60;
            Vector2 loc = transform.position;
            spawnPoints[1] = loc;
            spawnPoints[0] = new Vector2(loc.x, loc.y - spawnerGap);
            spawnPoints[2] = new Vector2(loc.x, loc.y + spawnerGap);
            // Checks spawn every 1s
            InvokeRepeating("Spawn", 0f, 1);
        }

        private bool firstSpawn = true;

        public void Spawn() {
            //If game is slowed or there is prefabs in the scene, don't spawn
            if (!firstSpawn) {
                if (GameManager.IsSlowed) {
                    return;
                }
                Prefab prefab = FindObjectOfType<Prefab>();
                if (prefab != null) {
                    return;
                }
            }

            firstSpawn = false;
            //Canister amount. 0 = none, 1 = one, 2 = two
            int rockAmount = Random.Range(0, 2);
            //Canister lane, 0 = top, 1 = middle, 2 = bottom
            int canisterLane = Random.Range(0, 3);
            //Spawn canister
            Instantiate(canisterPrefab, spawnPoints[canisterLane], Quaternion.identity);
            //Spawn rocks
            for (int i = 0; i < rockAmount; i++) {
                int rockLane = Random.Range(0, 3);
                if (rockLane != canisterLane) {
                    Instantiate(rockPrefab, spawnPoints[rockLane], Quaternion.identity);
                }
            }
        }
    }
}