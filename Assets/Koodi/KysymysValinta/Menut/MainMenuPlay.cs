using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Autopeli
{
    public class MainMenuPlay : MonoBehaviour
    {

        [SerializeField]
        public GameObject camera;

        [SerializeField] 
        public GameObject mainMenu;

        [SerializeField]
        public GameObject pauseButton;

        private void Awake()
        {
            camera.GetComponent<AudioListener>().enabled = false;
            //text.SetActive(true);
            
            
            Time.timeScale = 0;
        }

        public void Play()
        {
            mainMenu.SetActive(false);
            pauseButton.SetActive(true);
            // TÄHÄN LÄHTÖLASKENTA
            Time.timeScale = 1;

            //ResetTheGame();
            //mainMenu.SetActive(false);
        }

        public void ResetTheGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
