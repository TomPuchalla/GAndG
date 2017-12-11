using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinPatrolling : MonoBehaviour
{
    Rigidbody2D enemyrb;
    public float patrolForce;

    void Awake ()
    {
        enemyrb = GetComponent<Rigidbody2D>();
	}

    void Start()
    {
        StartCoroutine(GoblinPatrol());
    }

    IEnumerator GoblinPatrol()
    {
        while (true)
        {
            enemyrb.AddForce(new Vector2(patrolForce, 0), ForceMode2D.Impulse);
            yield return new WaitForSeconds(10);
            enemyrb.AddForce(new Vector2(-patrolForce, 0), ForceMode2D.Impulse);
            yield return new WaitForSeconds(10);
        }
    }
}
