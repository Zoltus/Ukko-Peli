using UnityEngine;

namespace Autopeli
{
    public class Pausing : MonoBehaviour
    {
        [SerializeField]
        public GameObject camera;

        [SerializeField]
        public GameObject menuToOpen;

        [SerializeField]
        public GameObject PauseButton;

        private void Awake()
        {
            camera.GetComponent<AudioListener>().enabled = false;
            //text.SetActive(true);


            //menuToOpen.SetActive(true);

            // Laitetaanko laskuri
            //Time.timeScale = 0;
        }

        public void PauseGame()
        {
            if (Time.timeScale > 0)
            {
                PauseButton.SetActive(false);
                camera.GetComponent<AudioListener>().enabled = false;
                //text.SetActive(true);
                menuToOpen.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                PauseButton.SetActive(true);
                camera.GetComponent<AudioListener>().enabled = true;
                menuToOpen.SetActive(false);
                //text.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}