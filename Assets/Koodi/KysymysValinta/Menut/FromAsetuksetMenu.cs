using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Autopeli
{
    public class FromAsetuksetMenu : MonoBehaviour
    {
        [SerializeField]
        public GameObject mainMenu;

        [SerializeField]
        public GameObject asetukset;

        public void poistuMenuun()
        {
            asetukset.SetActive(false);
            mainMenu.SetActive(true);
        }
    }
}
