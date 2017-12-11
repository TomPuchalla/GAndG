using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    public AudioClip musicPlaying;

    public AudioSource source;

    void Awake ()
    {
        source = GetComponent<AudioSource>();	
	}

    private void OnLevelWasLoaded(int hole)
    {
        if (hole == 0)
        {
            source.clip = musicPlaying;
            source.Play();
        }

        if (hole == 1)
        {
            source.clip = musicPlaying;
            source.Play();
        }

        if (hole == 2)
        {
            source.clip = musicPlaying;
            source.Play();
        }

        if (hole == 3)
        {
            source.clip = musicPlaying;
            source.Play();
        }

        if (hole == 4)
        {
            source.clip = musicPlaying;
            source.Play();
        }

        if (hole == 5)
        {
            source.clip = musicPlaying;
            source.Play();
        }

        if (hole == 6)
        {
            source.clip = musicPlaying;
            source.Play();
        }
    }
}
