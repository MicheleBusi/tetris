﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] GameEvent musicPaused = default;
    [SerializeField] GameEvent musicUnpaused = default;

    AudioSource audioSource = null;

    private void Awake()
    {
        // If a music player was already in the scene, destroy this.
        if (FindObjectsOfType<MusicPlayer>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();

        musicPaused.RegisterListener(SoftPause);
        musicUnpaused.RegisterListener(SoftUnpause);
    }

    public void SoftPause()
    {
        audioSource.volumeTransition(0f, 0.5f);
        this.Wait(0.5f, audioSource.Pause);
    }

    public void SoftUnpause()
    {
        audioSource.UnPause();
        audioSource.volumeTransition(0.45f, 0.5f);
    }
}