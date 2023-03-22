using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Autopeli
{
    public class FromAsetuksetMenu : MonoBehaviour
    {
        

        [SerializeField]
        public GameObject asetukset;

        public void poistuMenuun()
        {
            asetukset.SetActive(false);
            ToMainMenu();
            
        }

        public void ToMainMenu()
        {
            SceneManager.LoadScene(0); // 1 = game, 0 = menu
        }
    }
}
