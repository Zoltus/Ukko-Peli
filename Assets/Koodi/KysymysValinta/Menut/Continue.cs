using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Autopeli
{
    public class Continuing : MonoBehaviour
    {
        [SerializeField]
        public GameObject camera;

        [SerializeField]
        public GameObject menuToOpen;
        public void PauseGame()
        {
            if (Time.timeScale > 0)
            {
                camera.GetComponent<AudioListener>().enabled = false;
                //text.SetActive(true);
                menuToOpen.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                camera.GetComponent<AudioListener>().enabled = true;
                menuToOpen.SetActive(false);
                //text.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}
