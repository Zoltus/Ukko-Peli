using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Autopeli {
    public class Prefab : MonoBehaviour, Slowable {
        public float speed = 1f;
        private float orginalSpeed;
        private int speedSlowPercent = 50;

        public static bool slowed;

        public bool IsSlowed {
            get { return slowed; }
            set { slowed = value; }
        }
        void Start() {
            //Destroy the spawned objects after 9 seconds
            Destroy(gameObject, 9f);
        }

        void Update() {
            // Move the object to left at given speed
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        public void slowDown() {
            IsSlowed = true;
            orginalSpeed = speed;
            speed = speed / 100 * speedSlowPercent;
        }

        public void speedUp() {
            IsSlowed = false;
            speed = orginalSpeed;
        }

    }
}