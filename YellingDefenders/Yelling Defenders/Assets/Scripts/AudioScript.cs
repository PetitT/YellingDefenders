using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {

    static AudioSource audiosource;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public static void PlaySound(AudioClip clip)
    {
        audiosource.PlayOneShot(clip);
    }
}
