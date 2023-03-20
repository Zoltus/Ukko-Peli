using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

namespace Autopeli
{
    public class SelectQuestion : MonoBehaviour
    {
        public List<QuestionsAnswers> QnA;
        public GameObject[] options;
        public int currentQuestion;

        
        public TMP_Text QuestionTxt;


        private void Start()
        {
            // Toimiiko?
            generateQuestion();
        }
        public void correct()
        {
            QnA.RemoveAt(currentQuestion);
            generateQuestion();
        }


        void SetAnswers()
        {
            for (int i = 0; i < options.Length; i++)
            {
                options[i].GetComponent<AnswerScript>().isCorrect= false;
                options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnA[currentQuestion].Answers[i];
                

                if (QnA[currentQuestion].CorrectAnswer == i+1)
                {
                    options[i].GetComponent<AnswerScript>().isCorrect = true;
                    
                }
            }
        }


        void generateQuestion()
        {
            if (QnA.Count > 0)
            {
                currentQuestion = Random.Range(0, QnA.Count);

                QuestionTxt.text = QnA[currentQuestion].Question;

                SetAnswers();
            }
            else
            {
                Debug.Log("No questions left");
                return;
                
                
            }



        }

        

    }
}
