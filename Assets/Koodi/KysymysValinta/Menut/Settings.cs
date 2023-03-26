using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Autopeli
{
    public class Settings : MonoBehaviour
    {
        [SerializeField]
        public GameObject asetukset;
        [SerializeField]
        public GameObject menuToClose;
        public void openSettings()
        {
            asetukset.SetActive(true);
            menuToClose.SetActive(false);
        }

        
        
    }
}
