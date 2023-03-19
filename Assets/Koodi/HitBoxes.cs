using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

namespace Autopeli
{
    public class HitBoxes : MonoBehaviour
    {
        private static GameObject ui;

        


        private static AudioSource source;

        private void Awake()
        {
            source = GetComponent<AudioSource>();
            
            ui = GameObject.Find("Kysymys");
            
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            
            source.Play();

            Destroy(this.gameObject);

            ActivateUI activating = collision.gameObject.GetComponent<ActivateUI>();
            activating.OpenInterface();

            TaustanLiikuttaminen.SlowDown();
            
        }

        
    }
}
