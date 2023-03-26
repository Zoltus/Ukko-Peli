using UnityEngine;

namespace Autopeli {
    public class HitBoxes : MonoBehaviour {
        private static GameObject ui;
        private static AudioSource source;

        private void Awake() {
            source = GetComponent<AudioSource>();
            ui = GameObject.Find("Kysymys");
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            source.Play();
            Destroy(gameObject);
            if (Spawner.prefabs.Contains(gameObject)) {
                Spawner.prefabs.Remove(gameObject);
            }
            ActivateUI activating = collision.gameObject.GetComponent<ActivateUI>();
            if (activating != null) {
                activating.OpenInterface();
            }

            GameManager.slowDown();
        }
    }
}