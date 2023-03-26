using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Autopeli
{
    public class KillPlayer : MonoBehaviour
    {

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(collision.gameObject);
            OnApplicationQuit();
        }

        private void OnApplicationQuit()
        {
          //  UnityEditor.EditorApplication.isPlaying = false;
        }


    }
}
