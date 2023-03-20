using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Autopeli
{
    public class Pausing : MonoBehaviour
    {
        [SerializeField]
        public GameObject camera;

        private void Awake()
        {
            
        }
        public void PauseGame()
        {
            if (Time.timeScale > 0)
            {
                camera.GetComponent<AudioListener>().enabled = false;
                //text.SetActive(true);

                Time.timeScale = 0;
            }
            else
            {
                camera.GetComponent<AudioListener>().enabled = true;
                //text.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}
