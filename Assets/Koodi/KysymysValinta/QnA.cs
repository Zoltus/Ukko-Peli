using UnityEngine;

namespace Autopeli {
    [System.Serializable]
    public class QnA {
        public string Question;
        public string[] Answers;
        public int CorrectAnswer;

        public QnA(string question, int correctAnswer, params string[] answers) {
            Question = question;
            Answers = answers;
            CorrectAnswer = correctAnswer;
        }
    }

}