using UnityEngine;

namespace Autopeli
{
    public class KillPlayer : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            //Find inactivate Gameobject.
            GameObject gameover = GameObject.Find("Canvas").transform.Find("GameOver").gameObject;
            gameover.SetActive(true);
            SoundManager.Instance.carSoundSource.Stop();
            GameObject pausebutton = GameObject.Find("Kysymykset ja menu").transform.Find("PauseButton").gameObject;
            pausebutton.SetActive(false);
            Time.timeScale = 0;
            Destroy(collision.gameObject);
            OnApplicationQuit();
        }

        private void OnApplicationQuit()
        {
          //  UnityEditor.EditorApplication.isPlaying = false;
        }


    }
}
