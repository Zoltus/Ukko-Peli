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
                1, "7kk", "6kk", "4kk", ""),
            new QnA("Koeajan aikana työsopimuksen voi purkaa mistä tahansa syystä?",
                0, "Väärin.", "Oikein", "", ""),
            new QnA("Vain työnantajalla on oikeus purkaa työsopimus koeajalla.",
                0, "Väärin", "Oikein", "", ""),
            new QnA("Viisitoista vuotta täyttänyt saa työntekijänä itse tehdä sekä irtisanoa ja purkaa työsopimuksensa.",
                0, "Oikein ", "Väärin", "", ""),
            new QnA("Nuoren työntekijän (alle 18v) työaika ei saa ylittää yhdeksää tuntia vuorokaudessa eikä 48 tuntia viikossa.",
                0, "Oikein", "Väärin", "", ""),
            new QnA("Alle 18 vuotta täyttäneen henkilön työaika on pääsääntöisesti sijoitettava kello",
                0, "6-22 väliseen aikaan ", "8-20 väliseen aikaan", "-14 väliseen aikaan", "12-16 väliseen aikaan"),
            new QnA("Alle 18 vuotta täyttäneelle henkilölle on annettava vähintään ____ tuntia kestävä keskeytymätön lepoaika vuorokaudessa.",
                0, "12", "15", "9", "10"),
            new QnA("Alle 18 vuotta täyttäneelle on annettava vähintään 38 tuntia kestävä viikoittainen vapaa-aika keskeytymättömänä.",
                0, "Oikein", "Väärin", "", ""),
            new QnA("Ennen työsuhteen alkamista tai kuukauden kuluessa sen alkamisesta on nuorelle työntekijälle toimitettava terveystarkastus nuoren työntekijän omalla kustannuksella.",
                0, "Väärin ", "Oikein", "", ""),
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
                0, "Incorrect. However, the employment contract cannot be terminated on discriminatory or otherwise inappropriate grounds in relation to the purpose of the probationary period.", "Correct", "", ""),
            new QnA("Only the employer has the right to terminate the employment contract during the probationary period.",
                0, "Incorrect. During the probationary period, the employment contract can be terminated by both parties", "Correct.", "", ""),
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
                0, "Incorrect - It must be done at the employer's expense.", "Correct", "", ""),
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