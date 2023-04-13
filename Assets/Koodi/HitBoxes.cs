using System;
using TMPro;
using UnityEngine;

namespace Autopeli {
    public class HitBoxes : MonoBehaviour {
        private void OnCollisionEnter2D(Collision2D collision) {
            SoundManager.Instance.PlaySFX("CoinSound1");
            ActivateUI activating = collision.gameObject.GetComponent<ActivateUI>();
            if (activating != null) {
                activating.OpenInterface();
            }
            GameManager.slowDown();
            Destroy(gameObject);
        }
    }
}