using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Autopeli
{
    public class Speeding : MonoBehaviour {
        [SerializeField]
        private float addSpeedAmount = 0.05f;
        // Start is called before the first frame update
        void Start(){
            InvokeRepeating("AddSpeed", 0, 1f);
        }

       private void AddSpeed() {
           Debug.Log("Added");
           if (!GameManager.IsSlowed) {
               GameManager.addSpeed(addSpeedAmount);
           }
       }
    }
}
