using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

namespace Autopeli
{
    public class HitBoxes : MonoBehaviour
    {
        [SerializeField]
        private GameObject kysymys;
        
        private static AudioSource source;

        private void Awake()
        {
            source = GetComponent<AudioSource>();
            kysymys.SetActive(false);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            
            source.Play();
            Destroy(this.gameObject);
            kysymys.SetActive(true);
            TaustanLiikuttaminen.SlowDown();
            
        }

        
    }
}
