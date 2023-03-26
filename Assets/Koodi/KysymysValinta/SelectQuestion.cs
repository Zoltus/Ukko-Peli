using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Autopeli {
    public class SelectQuestion : MonoBehaviour {
        public enum Lang {
            FI,
            EN
        }

        public Lang lang;

        private List<QnA> QnA_EN;

        //Kysymykset jotka valitaan FI,EN Perusteella
        private List<QnA> questions;

        public GameObject[] options;
        public int currentQuestion;
        public TMP_Text QuestionTxt;

        private List<QnA> QnA_FI = new List<QnA>() {
            new QnA("Määräaikaisen työsopimuksen enimmäiskesto on?",
                0, "1 vuosi", "2 vuotta", "6 kuukautta", "ei enimmäisrajaa"),
            new QnA("Työsopimusta ei voi tehdä?",
                2, "Suullisesti", "Kirjallisesti", "Yksipuolisesti", "Sähköisesti"),
            new QnA("Koeaika on enintään?",
                1, "3kk", "6kk", "9kk", "12kk"),
            new QnA("Työntekijällä on oikeus sairausajan palkkaan, jos hän on aiheuttanut työkyvyttömyytensä tahallaan.",
                0, "Väärin", "Oikein", "", ""),
            new QnA("Työnantaja ei saa missään tapauksissa maksaa palkkaa käteisellä.",
                1, "Oikein", "Väärin", "", ""),
            new QnA("Kuinka monta päivää ennen työnantajan on ilmoitettava lomauttamisesta ennen lomautuksen alkamista?",
                3, "Yli vuorokausi", "Viisi päivää", "Seitsemän päivää", "Neljätoista päivää"),
            new QnA("Valitse väärä vaihtoehto koskien työntekijän irtisanoutumisaikaa",
                2, "14 päivää, jos työsuhde on jatkunut enintään viisi vuotta;", "yksi kuukausi, jos työsuhde on jatkunut yli viisi vuotta.", "yksi kuukausi, jos työsuhde on jatkunut yli kaksi vuotta.", ""),
            new QnA("Työnantaja saa irtisanoa toistaiseksi voimassa olevan työsopimuksen vain asiallisesta ja painavasta syystä.",
                0, "Oikein", "Väärin", "", ""),
            new QnA("Työnantaja saa irtisanoa toistaiseksi voimassa olevan työsopimuksen mikäli hän ei pidä työntekijästä.",
                0, "Väärin", "Oikein", "", ""),
            new QnA("Minkä näistä maininta ei kuulu hyvän työsopimuksen tunnuspiirteisiin?",
                3, "Palkka", "Työsopimuksen kesto", "Koeaika", "Siviilisääty"),
            new QnA("Säännöllinen työaika on enintään",
                0, "kahdeksan tuntia vuorokaudessa ja 40 tuntia viikossa.", "kymmenen tuntia vuorokaudessa ja 50 tuntia viikossa.", "kaksitoista tuntia vuorokaudessa.", ""),
            new QnA("Yötyötä on työ, joka tehdään",
                0, "23 ja 6 välisenä aikana", "21 ja 6 välisen aikana", "00.00 ja 6 välisenä aikana", ""),
            new QnA("Kuinka pitkä koeaika voi olla 14kk kestävässä työsuhteessa?",
                1, "7kk", "6kk", "4kk", "")
        };

        private void Start() {
            questions = lang == Lang.FI ? QnA_FI : QnA_EN;
            // Toimiiko?
            generateQuestion();
        }

        public void correct() {
            questions.RemoveAt(currentQuestion);
            generateQuestion();
        }

        void SetAnswers() {
            for (int i = 0; i < options.Length; i++) {
                options[i].GetComponent<AnswerScript>().isCorrect = false;
                options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = questions[currentQuestion].Answers[i];
                if (questions[currentQuestion].CorrectAnswer == i + 1) {
                    options[i].GetComponent<AnswerScript>().isCorrect = true;
                }
            }
        }

        void generateQuestion() {
            if (questions.Count > 0) {
                currentQuestion = Random.Range(0, questions.Count);
                QuestionTxt.text = questions[currentQuestion].Question;
                SetAnswers();
            }
            else {
                //Resets questions
                Start();
                Debug.Log("No questions left");
            }
        }
    }
}