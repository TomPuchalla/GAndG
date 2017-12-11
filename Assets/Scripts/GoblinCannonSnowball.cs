using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinCannonSnowball : MonoBehaviour
{
    public GameObject goblin;
    Rigidbody2D goblinrb;
    GameObject goblinFired;
    public float goblinFireSpeed;

    void Start()
    {
        StartCoroutine(GoblinCannonFire());
    }

    IEnumerator GoblinCannonFire()
    {
        while (true)
        {
            //goblinFired = Instantiate(goblin, transform.position, transform.rotation);
            //goblinFired = Instantiate(goblin, transform.position + new Vector3 (-2f,0.5f,0), Quaternion.Euler(0,0,0));
            goblinFired = Instantiate(goblin, transform.position + new Vector3 (0,0.25f,0), Quaternion.Euler(0, 0, 0));

            goblinrb = goblinFired.GetComponent<Rigidbody2D>();
            //goblinrb.AddForce(transform.forward * 1000);
            //goblinrb.AddForce(new Vector3(-90,0,0 * 100000 * Time.deltaTime));
            goblinrb.AddForce(-transform.right * goblinFireSpeed);
            //goblinrb.AddForce(new Vector2 (-90,0) * 50);
            Destroy(goblinFired, 25);
            yield return new WaitForSeconds(10);
        }
    }
}
