using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Autopeli
{
    public class UIController : MonoBehaviour
    {
        public Slider _musicSlider, _sfxSlider;

        public void ToggleMusic()
        {
            MenuSound.Instance.ToggleMusic();
        }

        public void ToggleSFX() 
        {
            MenuSound.Instance.ToggleSFX();
        }

        public void MusicVolume()
        {
            MenuSound.Instance.MusicVolume(_musicSlider.value);
        }

        public void SFXVolume()
        {
            MenuSound.Instance.SFXVolume(_sfxSlider.value);
        }

    }
}
