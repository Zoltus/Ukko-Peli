using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Autopeli
{
    public class Speeding : MonoBehaviour {
        [SerializeField]
        private int speedingPercent = 5;
        // Start is called before the first frame update
        void Start(){
            InvokeRepeating("AddSpeed", 0, 1f);
        }

       private void AddSpeed() {
           if (GameManager.IsSlowed) {
               GameManager.addSpeed(speedingPercent);
           }
       }
    }
}
