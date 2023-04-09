using UnityEngine;

namespace Autopeli {
    public class LanguageManager {
        // 0 = finland, 1 = english
        public static int getLanguage() {
           return PlayerPrefs.GetInt("language", 0);
        }

        public static void SetLanguage(int number) {
            if (number != 0 && number != 1) {
                number = 0;
            }
            Debug.Log("Language set to " + number);
            PlayerPrefs.SetInt("language", number);
            PlayerPrefs.Save();
        }
    }

}