using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Autopeli {
    public class SelectQuestion : MonoBehaviour {

        //Kysymykset jotka valitaan FI,EN Perusteella
        public List<QnA> questions;

        public bool hasBeenAswered;

        public GameObject[] options;
        public int currentQuestion;
        public TMP_Text QuestionTxt;

        private List<QnA> QnA_FI = new List<QnA>() {
            new QnA("Määräaikaisen työsopimuksen enimmäiskesto on?",
                0, "1 vuosi", "2 vuotta", "6 kuukautta", "ei enimmäisrajaa")
        };

        private List<QnA> QnA_EN= new List<QnA>() {
            new QnA("What is the maximum trial period in a 14-month employment contract?",
                1, "7 months", "6 months", "4 six months", "3 months"),
            new QnA("What is the maximum duration of a fixed-term employment contract?",
                0, "1 year", "2 years", "6 months", "no limit"),
            new QnA("A work contract cannot be made",
                2, "Verbally", "In writing", "Unilaterally ", "Electronically"),
            new QnA("The trial period is a maximum of",
                1, "3 months", "6 month", "9 months", "12 months"),
            new QnA("An employee is entitled to sick pay even if they have caused their incapacity intentionally.",
                0, "Wrong", "Correct", "", ""),
            new QnA("What is the notice period for an employer to inform an employee of a layoff before it begins?",
                3, "Over one day", "Five days", "Seven days", "Fourteen days"),
            new QnA("Choose the incorrect option regarding an employee's notice period:",
                2, "14 days if the employment relationship has lasted for up to five years.", "one month if the employment relationship has lasted for more than five years.", "one month if the employment relationship has lasted for more than two years.", ""),
            new QnA("An employer can terminate an indefinite-term employment contract only for a valid and weighty reason",
                1, "Wrong", "Correct", "", ""),
            new QnA("Which of these mentions does not belong to the characteristics of a good employment contract?",
                3, "Salary", "Duration of employment contract", "Probationary period", "Marital status"),
            new QnA("The regular working hours are a maximum of:",
                0, "Eight hours per day and 40 hours per week.", "Ten hours per day and 50 hours per week.", "Twelve hours per day.", ""),
            new QnA("Night work is work that is done ",
                0, " between 23 and 6 ", "between 21 and 6 ", " between 00:00 and 6", ""),
            new QnA("During the probationary period, can the employment contract be terminated for any reason?",
                0, "Incorrect", "Correct", "", ""),
            new QnA("Only the employer has the right to terminate the employment contract during the probationary period.",
                0, "Incorrect", "Correct", "", ""),
            new QnA("15-year-olds can work as employees and terminate or cancel their employment contracts themselves.",
                0, "True ", "False", "", ""),
            new QnA("The working hours of a young employee (under 18 years old) may not exceed nine hours per day or 48 hours per week.",
                0, "False", "Incorrect", "", ""),
            new QnA("The working hours of a person who has turned 18 years of age should generally be scheduled between which hours?",
                0, "6am-10pm", "8am-8pm", "9am-2pm", "12pm-4pm"),
            new QnA("At least ____ hours of uninterrupted rest must be given to a person who has reached the age of 18 years in a 24-hour period.",
                0, "12", "15", "9", "10"),
            new QnA("At least 38 hours of uninterrupted weekly free time must be given to anyone under 18 years old.",
                0, "Correct ", "Incorrect", "", ""),
            new QnA("Before the start of employment or within one month of its commencement, a young employee must be provided with a health examination at the young employee's own expense. ",
                0, "Incorrect", "Correct", "", ""),
        };


        private void Start() {
            questions = LanguageManager.getLanguage() == 0 ? new List<QnA>(QnA_FI) : new List<QnA>(QnA_EN);
            Debug.Log("Lang = " + LanguageManager.getLanguage());
            // Toimiiko?
            generateQuestion();
        }

        public void correct() {
            questions.RemoveAt(currentQuestion);
        }

        void SetAnswers() {
            for (int i = 0; i < options.Length; i++) {
                var option = options[i];
                var answerScript = option.GetComponent<AnswerScript>();
                var tmpText = option.transform.GetChild(0).GetComponent<TMP_Text>();
                var answer = questions[currentQuestion].Answers[i];
                var color = option.GetComponent<Image>();
                //Resets colors
                color.color = new Color32(3, 50, 245, 255);
                answerScript.isCorrect = false;
                tmpText.text = answer;
                if (answer.Equals("")) {
                    option.SetActive(false);
                } else {
                    option.SetActive(true);
                }
                if (questions[currentQuestion].CorrectAnswer == i) {
                    answerScript.isCorrect = true;
                }
            }
        }

        public void generateQuestion() {
            if (questions.Count != 0) {
                currentQuestion = Random.Range(0, questions.Count);
                QuestionTxt.text = questions[currentQuestion].Question;
                SetAnswers();
            }
            else {
                //Resets questions
                GameObject gameover = GameObject.Find("Canvas").transform.Find("GameOver").transform.Find("GameOverText").gameObject;
                var textMeshProUGUI = gameover.GetComponent<TextMeshProUGUI>();
                textMeshProUGUI.text = LanguageManager.getLanguage() == 0 ? "Voittaja!" : "Winner!";
                gameover.SetActive(true);
                SoundManager.Instance.carSoundSource.Stop();
                GameObject pausebutton = GameObject.Find("Kysymykset ja menu").transform.Find("PauseButton").gameObject;
                pausebutton.SetActive(false);
                Time.timeScale = 0;
                Debug.Log("No questions left");
            }
        }
    }
}