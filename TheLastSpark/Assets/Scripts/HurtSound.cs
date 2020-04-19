using UnityEngine;
using System.Collections;

public class HurtSound : MonoBehaviour {

    public AudioSource randomSound;


    public AudioClip[] audioSources;
    public AudioClip deathsound;
    public AudioClip healsound;
    // Use this for initialization


    public void RandomSoundness()
    {
        randomSound.clip = audioSources[Random.Range(0, audioSources.Length)];
        randomSound.Play();
    }
    public void DeathSound()
    {
        randomSound.clip = deathsound;
        randomSound.Play();
    }

    public void HealSound()
    {
        randomSound.clip = healsound;
        randomSound.Play();
    }

}
