using UnityEngine;

namespace Autopeli {
    public class Parallax : MonoBehaviour, Slowable {
        public bool IsSlowed {
            get { return IsSlowed; }
            set { IsSlowed = value; }
        }

        public static void slowMotionAll() {
            Object[] objects = FindObjectsOfType(typeof(Slowable));
            foreach (Slowable obj in objects) {
                obj.slowDown();
            }
        }
        public static void speedUpAll() {
            Object[] objects = FindObjectsOfType(typeof(Slowable));
            foreach (Slowable obj in objects) {
                obj.speedUp();
            }
        }

        [SerializeField]
        private float speed = .2f;
        private float orginalSpeed;
        private int speedSlowPercent = 50;
        private MeshRenderer _renderer;

        void Start() {
            _renderer = GetComponent<MeshRenderer>();
        }

        // Update is called once per frame
        void Update() {
            _renderer.material.mainTextureOffset += new Vector2((Time.deltaTime * speed) / 10f, 0);
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