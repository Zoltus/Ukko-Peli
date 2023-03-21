using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.Serialization;

namespace Autopeli
{
    public class SelectQuestion : MonoBehaviour
    {
        public enum Lang { FI,EN }
        public Lang lang;

        public List<QuestionsAnswers> QnA_FI;
        public List<QuestionsAnswers> QnA_EN;
        //Kysymykset jotka valitaan FI,EN Perusteella
        private List<QuestionsAnswers> questions;

        public GameObject[] options;
        public int currentQuestion;
        public TMP_Text QuestionTxt;

        private void Start()
        {
            questions = lang == Lang.FI ? QnA_FI : QnA_EN;
            // Toimiiko?
            generateQuestion();
        }
        public void correct()
        {
            questions.RemoveAt(currentQuestion);
            generateQuestion();
        }

        void SetAnswers()
        {
            for (int i = 0; i < options.Length; i++)
            {
                options[i].GetComponent<AnswerScript>().isCorrect= false;
                options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = questions[currentQuestion].Answers[i];
                if (questions[currentQuestion].CorrectAnswer == i+1)
                {
                    options[i].GetComponent<AnswerScript>().isCorrect = true;
                }
            }
        }

        void generateQuestion()
        {
            if (questions.Count > 0)
            {
                currentQuestion = Random.Range(0, questions.Count);
                QuestionTxt.text = questions[currentQuestion].Question;
                SetAnswers();
            }
            else
            {
                Debug.Log("No questions left");
            }
        }

    }
}