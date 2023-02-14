using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Autopeli
{
    public class Mover : MonoBehaviour
    {
        [SerializeField]
        private float speed = 1;

        private Vector2 direction;
        private InputReader inputReader;


        private void Awake()
        {
            inputReader = GetComponent<InputReader>();
        }


        private void Update()
        {
            this.direction = inputReader.GetMoveInput();
            Vector2 movement = this.speed * Time.fixedDeltaTime * direction;

            transform.Translate(movement);
        }
    }
}
