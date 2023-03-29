using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Autopeli
{
    public class MainMenuPlay : MonoBehaviour
    {

        //[SerializeField]
        //public GameObject camera;

        [SerializeField] 
        public GameObject mainMenu;


        private void Awake()
        {
            //camera.GetComponent<AudioListener>().enabled = false;
            //text.SetActive(true);
            
            
            Time.timeScale = 0;
        }

        public void Play()
        {
            mainMenu.SetActive(false);
            //pauseButton.SetActive(true);
            // TÄHÄN LÄHTÖLASKENTA
            ToGame();
            Time.timeScale = 1;
            if (SoundManager.Instance != null )
            {
                // äänet kuuluviin kun painaa play toisen kerran
                

                SoundManager.Instance.musicSource.Play();
                SoundManager.Instance.carSoundSource.Play();
            }
            else
            {
                
            }
            // uuteen skeneen main menu?
            //ResetTheGame();
            //mainMenu.SetActive(false);
        }
        public void ToGame()
        {
            SceneManager.LoadScene(1); // 1 = game, 0 = menu
        }

    }
}
