using System;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class AudioManager : SingletonDonDestroyOnLoad<AudioManager>
{
    [SerializeField] SoundList[] sfxSoundList;
    [SerializeField] SoundList[] musicSoundList;
    [SerializeField] AudioSource sfxSource;
    [SerializeField] AudioSource musicSource;
    void Start()
    {
        musicSource.loop = true;
    }
    public void PlaySound(SfxSoundType sound, float volume = 1)
    {
        AudioClip[] clips = Instance.sfxSoundList[(int)sound].Sounds;
        AudioClip randomSound = clips[UnityEngine.Random.Range(0, clips.Length)];
        Instance.sfxSource.PlayOneShot(randomSound, volume);
        //  Instance.audioSource.PlayOneShot(Instance.sfxSoundList[(int)sound]);
    }

    public void PlayMusic(MusicSoundType musicSound, float volume = 1)
    {
        StopMusic();
        AudioClip[] clips = Instance.musicSoundList[(int)musicSound].Sounds;
        AudioClip music = clips[0];
        musicSource.clip = music;
        musicSource.volume = volume;
        musicSource.Play();
    }
    public void StopMusic()
    {
        if (musicSource != null) musicSource.Stop();
    }
}

[Serializable]
public struct SoundList
{
    public AudioClip[] Sounds => sounds;
    [SerializeField] public string name;
    [SerializeField] AudioClip[] sounds;
}

public enum SfxSoundType
{
    Gun = 0,
    Explosion = 1,
    Coin = 2,
    Button = 3
}
public enum MusicSoundType
{
    Menu = 0,
    InGame = 1,
}