using UnityEngine;
using UnityEngine.UI;

namespace Autopeli
{
    public class EnglishButton : MonoBehaviour {
        [SerializeField] GameObject fiButton;
        public void changeLanguage() {
            Debug.Log("Changed to eng");
            LanguageManager.SetLanguage(1);

            SuomiButton.handleShadows();
        }
    }
}
