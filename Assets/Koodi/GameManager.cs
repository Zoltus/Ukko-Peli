using UnityEngine;

namespace Autopeli {
    public class GameManager {

        public static bool IsSlowed { get; set; }

        public static void slowDown() {
            Debug.Log("Speed");
            Parallax[] parallaxes = GameObject.FindObjectsOfType<Parallax>();
            Prefab[] prefabs = GameObject.FindObjectsOfType<Prefab>();
            //Combine 2 arrays:
            Slowable[] objects = new Slowable[parallaxes.Length + prefabs.Length];
            parallaxes.CopyTo(objects, 0);
            prefabs.CopyTo(objects, parallaxes.Length);

            foreach (var slowable in objects) {
                IsSlowed = true;
                slowable.slowDown();
            }
        }

        public static void speedUp() {
            Parallax[] parallaxes = GameObject.FindObjectsOfType<Parallax>();
            Prefab[] prefabs = GameObject.FindObjectsOfType<Prefab>();
            Slowable[] objects = new Slowable[parallaxes.Length + prefabs.Length];
            parallaxes.CopyTo(objects, 0);
            prefabs.CopyTo(objects, parallaxes.Length);

            foreach (var slowable in objects) {
                IsSlowed = false;
                slowable.speedUp();
            }
        }
    }
}