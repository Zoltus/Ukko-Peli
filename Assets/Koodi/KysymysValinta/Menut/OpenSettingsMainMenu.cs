using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Autopeli
{
    public class OpenSettingsMainMenu : MonoBehaviour
    {
        [SerializeField]
        public GameObject asetukset;

        public void OpenSettings()
        {
            asetukset.SetActive(true);
        }

    }
}
