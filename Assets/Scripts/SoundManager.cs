using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Ensure SoundManager persists across scenes if needed
        }
        else
        {
            Destroy(gameObject); // Ensure there's only one instance of SoundManager
        }
    }

    [SerializeField] private Sound[] sounds;

    [Serializable]
    public class Sound
    {
        public SoundName soundName;
        public AudioClip clip;
        [Range(0f, 1f)] public float volume;
        public bool loop;
        [HideInInspector] public AudioSource audioSource;
    }

    public enum SoundName
    {
        BGM,
        BGM2,
        Win,
        Lose,
        PickUpPhone,
        PhoneRing,
        CorrectSmt
    }

    public void Play(SoundName soundName)
    {
        Sound sound = GetSound(soundName);
        if (sound.audioSource == null)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.loop = sound.loop;
        }
        sound.audioSource.Play();
    }

    public void Stop(SoundName soundName)
    {
        Sound sound = GetSound(soundName);
        if (sound.audioSource != null && sound.audioSource.isPlaying)
        {
            sound.audioSource.Stop();
        }
    }

    private Sound GetSound(SoundName soundName)
    {
        return Array.Find(sounds, s => s.soundName == soundName);
    }
}