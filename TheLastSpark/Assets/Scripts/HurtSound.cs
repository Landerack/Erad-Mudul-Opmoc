using UnityEngine;
using System.Collections;

public class HurtSound : MonoBehaviour {

    public AudioSource randomSound;


    public AudioClip[] audioSources;
    public AudioClip deathsound;

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

}
