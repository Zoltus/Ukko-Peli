using UnityEngine;

namespace Autopeli {
    public class Spawner : MonoBehaviour {
        private Vector2[] spawnPoints = new Vector2[3];
        public float spawnRate = 7f;
        public float spawnerGap = 1f;

        public GameObject rockPrefab;
        public GameObject canisterPrefab;

        // Start is called before the first frame update
        void Start() {
            Vector2 loc = transform.position;
            spawnPoints[1] = loc;
            spawnPoints[0] = new Vector2(loc.x, loc.y - spawnerGap);
            spawnPoints[2] = new Vector2(loc.x, loc.y + spawnerGap);
            // Spawn the prefabs repeatedly, every 7 seconds
            InvokeRepeating("Spawn", 0f, spawnRate);
        }

        private void Spawn() {
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