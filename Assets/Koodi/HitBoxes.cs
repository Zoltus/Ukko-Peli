using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Autopeli
{
    public class HitBoxes : MonoBehaviour
    {

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(this.gameObject);
            
        }

       
    }
}
