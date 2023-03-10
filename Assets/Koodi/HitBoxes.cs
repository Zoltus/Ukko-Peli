using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Autopeli
{
    public class HitBoxes : MonoBehaviour
    {
        [SerializeField]
        private GameObject kysymys;



        private void Awake()
        {
    
            
            kysymys.SetActive(false);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(this.gameObject);
            kysymys.SetActive(true);
            
        }

        
    }
}
