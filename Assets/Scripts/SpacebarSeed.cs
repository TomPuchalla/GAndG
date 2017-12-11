using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacebarSeed : MonoBehaviour {

    public GameObject spacebarSeed;
    public GameObject spacebarSecret;
    private Rigidbody2D playerrb;

    void Awake()
    {
        spacebarSecret.SetActive(false);
        playerrb = GetComponent<Rigidbody2D>();
    }

    void Start ()
    {
        spacebarSecret.SetActive(false);
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == spacebarSeed)
        {
            spacebarSecret.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == spacebarSeed)
        {
            spacebarSecret.SetActive(false);
        }
    }
}
