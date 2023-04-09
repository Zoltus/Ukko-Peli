using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Autopeli
{
    public class AnswerScript : MonoBehaviour
    {
        public bool isCorrect;

        public SelectQuestion selectQuestion;

        public void Answer()
        {
            var image = GetComponent<Image>();
            var imageColor = image.color;
            Debug.Log("Color is: " + imageColor);
            // TÄHÄN JOTAIN
            if(isCorrect)
            {
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
