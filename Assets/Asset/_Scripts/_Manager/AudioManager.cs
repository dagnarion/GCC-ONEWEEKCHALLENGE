using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] SoundList[] soundList;
    AudioSource audioSource;
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }
    public static void PlaySound(SoundType sound, float volume = 1)
    {
        AudioClip[] clips = Instance.soundList[(int)sound].Sounds;
        AudioClip randomSound = clips[UnityEngine.Random.Range(0, clips.Length)];
        Instance.audioSource.PlayOneShot(randomSound);
        //  Instance.audioSource.PlayOneShot(Instance.soundList[(int)sound]);
    }
}
[Serializable]
public struct SoundList
{
    public AudioClip[] Sounds => sounds;
    [SerializeField] public string name;
    [SerializeField] AudioClip[] sounds;
}

public enum SoundType
{
    Bullet = 0,
    PlayerHit = 1,
    PlayerDead = 2,
    EnemyHit = 3,
    EnemyDead = 4,
    Coin = 5
}