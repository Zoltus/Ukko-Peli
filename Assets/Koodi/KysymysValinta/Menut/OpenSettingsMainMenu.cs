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
            MenuSound.Instance.PlaySFX("UI_SE1");
            asetukset.SetActive(true);
        }

    }
}
