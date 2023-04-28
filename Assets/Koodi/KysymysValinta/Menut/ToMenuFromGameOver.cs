using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Autopeli
{
    public class ToMenuFromGameOver : MonoBehaviour
    {

        [SerializeField]
        public GameObject pause;

        public void poistuMenuun()
        {
            Debug.Log("CLICKKK");
            pause.SetActive(false);
            ToMainMenu();
        }
        public void ToMainMenu()
        {
            SceneManager.LoadScene(0); // 1 = game, 0 = menu
            SoundManager.Instance.musicSource.Stop();
            MenuSound.Instance.musicSource.Play();
        }
    }
}
