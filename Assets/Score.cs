using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Autopeli
{
    public class Score : MonoBehaviour {
        // Start is called before the first frame update
        void Start(){
            String lang = LanguageManager.getLanguage() == 0 ? "Pisteet: " : "Score: ";
            GetComponent<TextMeshProUGUI>().text = lang + GameManager.points;
        }

        // Update is called once per frame
        void Update() {
        
        }
    }
}
