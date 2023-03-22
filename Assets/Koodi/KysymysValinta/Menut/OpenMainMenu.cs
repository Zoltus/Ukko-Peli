using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Autopeli
{
    public class OpenMainMenu : MonoBehaviour
    {
        [SerializeField]
        public GameObject mainMenu;
        void Start()
        {
            mainMenu.SetActive(true);
        }

        
    }
}
