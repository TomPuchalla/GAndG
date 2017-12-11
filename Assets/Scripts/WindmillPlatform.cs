using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillPlatform : MonoBehaviour
{

    Rigidbody2D rb;

    void Awake ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate ()
    {
        rb.transform.rotation = Quaternion.Euler(0,0,0);
	}
}
