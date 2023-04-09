using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Autopeli
{
    public class EnglishButton : MonoBehaviour {
        public void changeLanguage() {
            Debug.Log("Changed to eng");
            LanguageManager.SetLanguage(1);
        }
    }
}
