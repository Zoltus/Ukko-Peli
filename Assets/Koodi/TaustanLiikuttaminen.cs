using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}

