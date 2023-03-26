using UnityEngine;

namespace Autopeli {
    public class Parallax : MonoBehaviour {

        public static bool hasSlomo = false;
        public static void slowMotionAll() {
            hasSlomo = true;
            Parallax[] parallaxObjects = FindObjectsOfType<Parallax>();
            foreach (Parallax parallax in parallaxObjects) {
                parallax.slowMotion();
            }
        }

        public static void normalMotionAll() {
            hasSlomo = false;
            Parallax[] parallaxObjects = FindObjectsOfType<Parallax>();
            foreach (Parallax parallax in parallaxObjects) {
                parallax.normalMotion();
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

        private void slowMotion() {
            orginalSpeed = speed;
            speed = speed / 100 * speedSlowPercent;
        }

        private void normalMotion() {
            speed = orginalSpeed;
        }
    }
}