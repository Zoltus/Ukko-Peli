using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Autopeli
{
    public class TaustanLiikuttaminen : MonoBehaviour
    {
        // Alustetaan nopeus ja startti positio
        [SerializeField]
        private float speed = 4f;
        private Vector2 StartPosition;
        [SerializeField]
        private double temp = -24.8;

        static TaustanLiikuttaminen nopeus;

        void Start()
        {
            // Tallennetaan starter positio
            StartPosition = transform.position;

            
        }

        // Update is called once per frame
        void Update()
        {
            // Liikutetaan kuvaa vasemmalle tietyll‰ nopeudella, jolloin syntyy illuusio ett‰ hahmo liikkuu oikealle
            transform.Translate(Vector2.left * speed * Time.deltaTime);

            // Jos menn‰‰n backgroundin loppuun niin se looppaa hahmon takaisin alkuun
            if (transform.position.x < temp)
            {
                transform.position = StartPosition;
            }
        }

        

        // Takes all of the moving things and slows them all down
        public static void SlowDown()
        {
            GameObject[] speeding = GameObject.FindGameObjectsWithTag("Tausta");
            foreach (GameObject speedy in speeding)
            {
                nopeus = speedy.GetComponent<TaustanLiikuttaminen>();
                nopeus.speed = 0.5f;
            }
        }
        public static void SpeedUp()
        {
            GameObject[] speeding = GameObject.FindGameObjectsWithTag("Tausta");
            foreach (GameObject speedy in speeding)
            {
                nopeus = speedy.GetComponent<TaustanLiikuttaminen>();
                nopeus.speed = 4f;
            }
        }


    }
}

