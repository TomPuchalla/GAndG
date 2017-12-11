using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinKing : MonoBehaviour
{
    private AudioSource source;
    public AudioClip goblinKingLaugh;

    public GameObject p;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == p)
        {
            source.clip = goblinKingLaugh;
            source.Play();
        }
    }
}
