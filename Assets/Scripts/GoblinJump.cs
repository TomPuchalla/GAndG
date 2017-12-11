using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinJump : MonoBehaviour
{
    Rigidbody2D enemyrb;

    void Awake()
    {
        enemyrb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        StartCoroutine(GoblinJumping());
    }


    IEnumerator GoblinJumping()
    {
        while (true)
        {
            enemyrb.AddForce(new Vector2(0, 10),ForceMode2D.Impulse);
            yield return new WaitForSeconds(5);
        }
    }
}
