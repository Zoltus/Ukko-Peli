using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Autopeli
{
    public class MenuSound : MonoBehaviour
    {
        public Sound[] musicSounds, sfxSounds;
        public AudioSource musicSource, sfxSource;

        public static MenuSound Instance;



        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            //PlayMusic("Demo_musaa");
            //PlayCar("Ajoneuvoaani4");
            PlayMusic("Menumusat2");

        }


        public void PlayMusic(string name)
        {
            Sound s = Array.Find(musicSounds, x => x.name == name);

            if (s == null)
            {
                Debug.Log("Sound not found");
            }
            else
            {
                musicSource.clip = s.clip;
                musicSource.Play();
            }
        }
        

        public void PlaySFX(string name)
        {
            Sound s = Array.Find(sfxSounds, x => x.name == name);

            if (s == null)
            {
                Debug.Log("Sound not found");
            }
            else
            {
                sfxSource.PlayOneShot(s.clip);
            }
        }

        public void ToggleMusic()
        {
            musicSource.mute = !musicSource.mute;
        
        }

        public void ToggleSFX()
        {
            sfxSource.mute = !sfxSource.mute;
        }

        public void MusicVolume(float volume)
        {
            musicSource.volume = volume;
       
        }

        public void SFXVolume(float volume)
        {
            sfxSource.volume = volume;
        }

    }
}
