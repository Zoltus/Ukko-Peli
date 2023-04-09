using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Autopeli
{
    public class SuomiButton : MonoBehaviour {
        public void changeLanguage() {
            Debug.Log("Changed to fi");
            LanguageManager.SetLanguage(0);
        }
    }
}
