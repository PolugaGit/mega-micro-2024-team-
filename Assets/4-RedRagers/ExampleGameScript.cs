﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RedRagers{
    public class ExampleGameScript : MonoBehaviour
    {
        // DELETE THIS FILE BEFORE YOU SUBMIT //
        public TextMeshProUGUI UIText;
        public string startText;
        public string winText;
        public bool showDifficultyInStartText;

        public AudioClip loopSound;
        public AudioClip winSound;

        private void Start()
        {
            UIText.text = startText;

            if(showDifficultyInStartText)
            {
                UIText.text += $" on {Managers.MinigamesManager.GetCurrentMinigameDifficulty().ToString()}";
            }
            
            AudioSource loop = Managers.AudioManager.CreateAudioSource();
            loop.loop = true;
            loop.clip = loopSound;
            loop.Play();
        }

        private void Update()
        {
            if (Input.GetButtonDown("Space"))
            {
                UIText.text = winText;

                AudioSource win = Managers.AudioManager.CreateAudioSource();
                win.PlayOneShot(winSound);

                Managers.MinigamesManager.DeclareCurrentMinigameWon();
                Managers.MinigamesManager.EndCurrentMinigame(1f);
                this.enabled = false;
            }
        }
    }
}
