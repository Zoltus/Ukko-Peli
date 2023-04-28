using UnityEngine;

namespace Autopeli {
    public class Parallax : MonoBehaviour, Slowable {

        [SerializeField] private float speed = 2f;
        private float orginalSpeed;
        public int speedSlowPercent = 50;
        private MeshRenderer _renderer;

        private void Start() {
            _renderer = GetComponent<MeshRenderer>();
        }

        // Update is called once per frame
        private void Update() {
            _renderer.material.mainTextureOffset += new Vector2(Time.deltaTime * speed / 10f, 0);
        }

        public void slowDown() {
            if (!GameManager.IsSlowed) return;
            Debug.Log("Slow2");
            orginalSpeed = speed;
            speed = speed / 100 * speedSlowPercent;
        }

        public void speedUp() {
            if (!GameManager.IsSlowed) {
                speed = orginalSpeed;
            }
        }

        public void addSpeed(float percent) {
            speed += percent;
        }
    }
}