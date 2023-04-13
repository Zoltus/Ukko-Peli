using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Autopeli
{
    public class KillPlayer : MonoBehaviour
    {

        private GameObject gameover;

        private void Start() {
            gameover = GameObject.Find("GameOver");
            gameover.SetActive(false);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            gameover.SetActive(true);
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
