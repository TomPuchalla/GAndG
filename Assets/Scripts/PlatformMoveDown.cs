using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoveDown : MonoBehaviour {

    Rigidbody2D rb;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate ()
    {
        //rb.transform.Translate(Vector3.down * Time.deltaTime);
        rb.transform.Translate(0,-0.01f,0 * Time.deltaTime);
    }
}
