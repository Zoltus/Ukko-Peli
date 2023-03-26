using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Autopeli
{
    public class BackToPause : MonoBehaviour
    {

        [SerializeField]
        public GameObject backToPause;

        [SerializeField] 
        public GameObject asetuksetToClose;

        public void toPause()
        {
            backToPause.SetActive(true);
            asetuksetToClose.SetActive(false);
        }

    }
}
