using UnityEngine;

namespace Autopeli
{
    public class Pausing : MonoBehaviour
    {

        [SerializeField]
        public GameObject menuToOpen;

        [SerializeField]
        public GameObject PauseButton;

        private void Awake()
        {
            
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
                SoundManager.Instance.carSoundSource.Stop();
                //text.SetActive(true);
                menuToOpen.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                PauseButton.SetActive(true);
                SoundManager.Instance.carSoundSource.Play();
                menuToOpen.SetActive(false);
                //text.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}