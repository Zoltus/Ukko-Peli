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
        public GameObject car;
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

            if (selectQuestion.questions.Count == 0) {


                //Find inactivate Gameobject.
                GameObject gameover = GameObject.Find("Canvas").transform.Find("GameOver").gameObject;
                gameover.SetActive(true);
                SoundManager.Instance.carSoundSource.Stop();
                GameObject pausebutton = GameObject.Find("Kysymykset ja menu").transform.Find("PauseButton").gameObject;
                pausebutton.SetActive(false);
                Time.timeScale = 0;

                GameObject gameoverText = GameObject.Find("Canvas").transform.Find("GameOver").transform.Find("GameOverText").gameObject;
                var textMeshProUGUI = gameoverText.GetComponent<TextMeshProUGUI>();
                textMeshProUGUI.text = LanguageManager.getLanguage() == 0 ? "Voittaja!" : "Winner!";

                Destroy(car.gameObject);

                var kysymys = GameObject.Find("Kysymykset ja menu").transform.Find("Kysymys");
                kysymys.gameObject.SetActive(false);
            }


        }
    }
}
