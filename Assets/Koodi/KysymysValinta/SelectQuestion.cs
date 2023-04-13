using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Autopeli {
    public class SelectQuestion : MonoBehaviour {

        //Kysymykset jotka valitaan FI,EN Perusteella
        private List<QnA> questions;

        public bool hasBeenAswered;

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

        private List<QnA> QnA_EN= new List<QnA>() {
            new QnA("aaMääräaikaisen työsopimuksen enimmäiskesto on?",
                0, "1 vuosi", "2 vuotta", "6 kuukautta", "ei enimmäisrajaa"),
            new QnA("aaTyösopimusta ei voi tehdä?",
                2, "Suullisesti", "Kirjallisesti", "Yksipuolisesti", "Sähköisesti"),
            new QnA("aaKoeaika on enintään?",
                1, "3kk", "6kk", "9kk", "12kk"),
            new QnA("aaTyöntekijällä on oikeus sairausajan palkkaan, jos hän on aiheuttanut työkyvyttömyytensä tahallaan.",
                0, "Väärin", "Oikein", "", ""),
            new QnA("aaTyönantaja ei saa missään tapauksissa maksaa palkkaa käteisellä.",
                1, "Oikein", "Väärin", "", ""),
            new QnA("aaKuinka monta päivää ennen työnantajan on ilmoitettava lomauttamisesta ennen lomautuksen alkamista?",
                3, "Yli vuorokausi", "Viisi päivää", "Seitsemän päivää", "Neljätoista päivää"),
            new QnA("aaValitse väärä vaihtoehto koskien työntekijän irtisanoutumisaikaa",
                2, "14 päivää, jos työsuhde on jatkunut enintään viisi vuotta;", "yksi kuukausi, jos työsuhde on jatkunut yli viisi vuotta.", "yksi kuukausi, jos työsuhde on jatkunut yli kaksi vuotta.", ""),
            new QnA("aaTyönantaja saa irtisanoa toistaiseksi voimassa olevan työsopimuksen vain asiallisesta ja painavasta syystä.",
                0, "Oikein", "Väärin", "", ""),
            new QnA("aaTyönantaja saa irtisanoa toistaiseksi voimassa olevan työsopimuksen mikäli hän ei pidä työntekijästä.",
                0, "Väärin", "Oikein", "", ""),
            new QnA("aaMinkä näistä maininta ei kuulu hyvän työsopimuksen tunnuspiirteisiin?",
                3, "Palkka", "Työsopimuksen kesto", "Koeaika", "Siviilisääty"),
            new QnA("aaSäännöllinen työaika on enintään",
                0, "kahdeksan tuntia vuorokaudessa ja 40 tuntia viikossa.", "kymmenen tuntia vuorokaudessa ja 50 tuntia viikossa.", "kaksitoista tuntia vuorokaudessa.", ""),
            new QnA("aaYötyötä on työ, joka tehdään",
                0, "23 ja 6 välisenä aikana", "21 ja 6 välisen aikana", "00.00 ja 6 välisenä aikana", ""),
            new QnA("aaKuinka pitkä koeaika voi olla 14kk kestävässä työsuhteessa?",
                1, "7kk", "6kk", "4kk", "")
        };


        private void Start() {
            questions = LanguageManager.getLanguage() == 0 ? QnA_FI : QnA_EN;
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