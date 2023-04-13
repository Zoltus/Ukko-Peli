using UnityEngine;

namespace Autopeli
{
    public class ActivateUI : MonoBehaviour
    {
        [SerializeField]
        private GameObject toOpen;

        public void OpenInterface()
        {
            if (toOpen != null) {
                //Generates new questions when the UI is opened
                var selectQuestion = GameObject.Find("QuizManager").GetComponent<SelectQuestion>();
                selectQuestion.hasBeenAswered = false;
                selectQuestion.generateQuestion();
                toOpen.SetActive(true);
            }
        }
    }
}
