using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Autopeli
{
    public class ClosingUI : MonoBehaviour
    {
        
        [SerializeField]
        private GameObject toClose;

        public void CloseInterface()
        {
            Debug.Log("Close");
            //closes interface after 2 seconds, so player sees if he answered wrong or right
            StartCoroutine(ExecuteAfter(2));
        }

        IEnumerator ExecuteAfter(float time)
        {
            yield return new WaitForSeconds(time);
            // Code to execute after the delay
            toClose.SetActive(false);
            GameObject pausebutton = GameObject.Find("Kysymykset ja menu").transform.Find("PauseButton").gameObject;
            pausebutton.SetActive(true);
            GameManager.speedUp();
        }


    }
}
