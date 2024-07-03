using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioSource SFXAudioSource;
    [SerializeField] private AudioMixer mixer;

    [Header ("Music Tracks")]
    public AudioClip generalMusic;
    public AudioClip obstaclesSceneMusic;

    [Header("SFX Tracks")]
    public AudioClip clickButtonSFX;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void LoadMain()
    {
        GameObject main = GameObject.Instantiate(Resources.Load("AudioManager")) as GameObject;
        GameObject.DontDestroyOnLoad(main);
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static AudioManager GetInstance()
    {
        return instance;
    }

    public void PlayMusicClip(AudioClip clip)
    {
        musicAudioSource.clip = clip;
        musicAudioSource.Play();
    }

    public void PlaySFXClip(AudioClip clip)
    {
        SFXAudioSource.clip = clip;
        SFXAudioSource.Play();
    }

    public void SetMusicVolume(float sliderValue)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue)*20);
    }

    public void SetSFXVolume(float sliderValue)
    {
        mixer.SetFloat("SFXVolume", Mathf.Log10(sliderValue) * 20);
    }
}
