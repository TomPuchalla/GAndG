using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsAndParticles : MonoBehaviour
{
    
    //Player player;
    EffectsAndParticles effectsAndParticles;
    public GameObject waterSplashGO;
    public ParticleSystem waterSplash;

    void Awake()
    {
        //waterSplash = waterSplashGO.GetComponent<ParticleSystem>();
    }

    /*void OnTriggerEnter2D(Collider other)
    {
        if (other.gameObject.tag == "Player")// || other.tag == "Enemy")
        {
            Debug.Log("waterSplash > player");
            //Instantiate(waterSplash, other.transform.position, other.transform.rotation);
            Instantiate(waterSplash, transform.position, Quaternion.identity);
            //Instantiate(waterSplash, new Vector3(other.transform.position.x, other.transform.position.y, 0), Quaternion.identity);

            waterSplash.Play();
        }
    }*/
}
