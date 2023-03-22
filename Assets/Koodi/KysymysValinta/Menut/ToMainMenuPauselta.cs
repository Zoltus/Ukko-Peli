using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Autopeli
{
    public class ToMainMenuPauselta : MonoBehaviour
    {
        [SerializeField]
        public GameObject mainMenu;

        [SerializeField]
        public GameObject pause;

        public void poistuMenuun()
        {
            pause.SetActive(false);
            mainMenu.SetActive(true);
        }

    }
}
