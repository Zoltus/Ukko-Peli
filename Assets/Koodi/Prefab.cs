using UnityEngine;

namespace Autopeli {
    public class Prefab : MonoBehaviour, Slowable {
        //todo to global thingy

        public float speed = 2.63f;
        private float orginalSpeed;
        private int speedSlowPercent = 50;

        void Start() {
            orginalSpeed = speed;
            //Slows obj on spawn if slomo is on
            slowDown();
        }

        void Update() {
            // Move the object to left at given speed
            transform.Translate(Vector2.left * speed * Time.deltaTime);

            if (gameObject.transform.position.x <= -9) {
                Destroy(gameObject);
            }
        }

        public void slowDown() {
            if (GameManager.IsSlowed) {
                speed = orginalSpeed / 100 * speedSlowPercent;
            }
        }

        public void speedUp() {
            if (!GameManager.IsSlowed) {
                speed = orginalSpeed;
            }
        }

        public void addSpeed(int percent) {
            speed *= percent;
        }
    }
}