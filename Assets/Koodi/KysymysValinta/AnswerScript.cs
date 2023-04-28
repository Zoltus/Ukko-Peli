using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Autopeli
{
    public class AnswerScript : MonoBehaviour
    {
        public bool isCorrect;

        public SelectQuestion selectQuestion;
        private TextMeshProUGUI pointsText;
        private void Start() {
            pointsText = GameObject.Find("Points").GetComponent<TextMeshProUGUI>();
        }

        public void Answer()
        {
            if (selectQuestion.hasBeenAswered) {
                return;
            }
            selectQuestion.hasBeenAswered = true;
            var image = GetComponent<Image>();
            var imageColor = image.color;
            Debug.Log("Color is: " + imageColor);

            String lang = LanguageManager.getLanguage() == 0 ? "Pisteet: " : "Score: ";
            // TÄHÄN JOTAIN
            if(isCorrect)
            {
                GameManager.points += 1;
                pointsText.text = lang+ GameManager.points;
                Debug.Log("Correct Answer");
                selectQuestion.correct();
                image.color = Color.green;
            }
            else
            {
                Debug.Log("Wrong Answer");
                //Muuta
                selectQuestion.correct();
                image.color = Color.red;
            }
        }
    }
}
