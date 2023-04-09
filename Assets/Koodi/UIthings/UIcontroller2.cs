using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Autopeli
{
    public class UIcontroller2 : MonoBehaviour
    {
        public Slider _musicSlider, _sfxSlider;

        public void ToggleMusic()
        {
            SoundManager.Instance.ToggleMusic();
        }

        public void ToggleSFX()
        {
            SoundManager.Instance.ToggleSFX();
        }

        public void MusicVolume()
        {
            SoundManager.Instance.MusicVolume(_musicSlider.value);
        }

        public void SFXVolume()
        {
            SoundManager.Instance.SFXVolume(_sfxSlider.value);
        }

    }
}
