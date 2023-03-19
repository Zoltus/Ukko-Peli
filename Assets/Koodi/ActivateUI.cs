using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Autopeli
{
    public class ActivateUI : MonoBehaviour
    {
        [SerializeField]
        private GameObject toOpen;

        public void OpenInterface()
        {
            if (toOpen != null)
            {
                toOpen.SetActive(true);
            }

        }
    }
}
