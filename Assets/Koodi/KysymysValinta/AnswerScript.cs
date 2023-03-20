using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Autopeli
{
    public class AnswerScript : MonoBehaviour
    {
        public bool isCorrect = false;

        public SelectQuestion selectQuestion;

        public void Answer()
        {
            // TÄHÄN JOTAIN
            if(isCorrect)
            {
                Debug.Log("Correct Answer");
                selectQuestion.correct();

            }
            else
            {
                Debug.Log("Wrong Answer");
                //Muuta
                selectQuestion.correct();
            }
        }
    }
}
