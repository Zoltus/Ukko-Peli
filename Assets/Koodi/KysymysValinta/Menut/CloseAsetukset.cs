using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Autopeli
{
    public class CloseAsetukset : MonoBehaviour
    {
        [SerializeField]
        public GameObject asetukset;
        public void Close()
        {
            MenuSound.Instance.PlaySFX("UI_SE1");
            asetukset.SetActive(false);
        }


    }
}
