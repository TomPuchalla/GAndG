using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossElevator : MonoBehaviour
{
    Rigidbody2D elevator;
    public GameObject player;
    Vector3 startPos;
    Vector3 endPos;
    public Rigidbody2D playerrb;
    public GameObject elevatorButton;
    SpriteRenderer elevatorButtonSpriteRenderer;

	void Awake ()
    {
        elevator = GetComponent<Rigidbody2D>();
        //startPos = transform.position;
        startPos = new Vector3 (208.15f, 29f, 0);
        //endPos = transform.position + new Vector3(0, 97.25f, 0);
        endPos = new Vector3(208.15f, 66.25f, 0);
        elevatorButtonSpriteRenderer = elevatorButton.GetComponent<SpriteRenderer>();
    }
	
	void FixedUpdate ()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, startPos.y, endPos.y), transform.position.z);
        //elevator.velocity = Mathf.Clamp(elevator.velocity.magnitude, 0, 100);

        elevator.velocity = Vector2.ClampMagnitude(elevator.velocity, 10f);

        //if (transform.position == endPos)
        {
            
            //elevator.AddForce(Vector2.down * 0 * Time.deltaTime);
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        //if (collider.tag == "Player")
        if (collider.gameObject == player && transform.position.y < 66.25f)
        {
            //elevator.transform.position = Vector3.MoveTowards(startPos, endPos, 10);
            elevator.AddForce(Vector2.up * 10000 * Time.deltaTime);
            //elevator.transform.position.x = new Vector3(0, 0, 0);
            Debug.Log("elevator up");
            //Vector3.MoveTowards(startPos, endPos, 10);
            elevatorButtonSpriteRenderer.color = Color.yellow;
        }
        if (collider.gameObject == player && transform.position.y >= 60f)
        {
            //elevator.AddForce(Vector2.up * 5000 * Time.deltaTime);
            elevatorButtonSpriteRenderer.color = Color.green;
        }

    }

    void OnTriggerExit2D(Collider2D collider)
    {
        //if (collider.tag == "Player")
        if (collider.gameObject == player)
        {
            //elevator.transform.position = Vector3.MoveTowards(transform.position, startPos, 1000);
            //elevator.AddForce(Vector2.up * 0 * Time.deltaTime);
            //elevator.transform.position.x = new Vector3(0, 0, 0);
            Debug.Log("elevator down");
            //Vector3.MoveTowards(startPos, endPos, 10);

            elevatorButtonSpriteRenderer.color = Color.red;
        }
    }
}
