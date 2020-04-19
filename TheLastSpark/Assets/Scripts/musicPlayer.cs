using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource thisAudio;
    void Start()
    {
        thisAudio.Play();
    }

}
