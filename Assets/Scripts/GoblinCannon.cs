using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinCannon : MonoBehaviour
{
    public GameObject goblin;
    Rigidbody2D goblinrb;
    GameObject goblinFired;

    void Start()
    {
        StartCoroutine(GoblinCannonFire());
    }

    IEnumerator GoblinCannonFire()
    {
        while (true)
        {
            goblinFired = Instantiate(goblin, transform.position, transform.rotation);
            goblinrb = goblinFired.GetComponent<Rigidbody2D>();
            //goblinrb.AddForce(transform.forward * 1000);
            //goblinrb.AddForce(new Vector3(-90,0,0 * 100000 * Time.deltaTime));
            goblinrb.AddForce(-transform.right * 1000);
            Destroy(goblinFired, 10);
            yield return new WaitForSeconds(5);
        }
    }
}
