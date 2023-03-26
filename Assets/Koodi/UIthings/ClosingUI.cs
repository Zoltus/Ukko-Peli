using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Autopeli {
    public class ClosingUI : MonoBehaviour {
        [SerializeField] private GameObject toClose;

        public void CloseInterface() {
            toClose.SetActive(false);
            GameManager.speedUp();
        }
    }
}