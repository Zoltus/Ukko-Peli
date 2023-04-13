using System.Collections;
using System.Collections.Generic;
using TMPro;
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
