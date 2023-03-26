using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Autopeli
{
    public class CloseUI : MonoBehaviour
    {
        [SerializeField]
        private GameObject toClose;
        private void Start()
        {
            CloseInterfaceNoSpeed();
        }
        public void CloseInterfaceNoSpeed()
        {
            toClose.SetActive(false);
        }
    }
}
