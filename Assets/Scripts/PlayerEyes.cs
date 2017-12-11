using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEyes : MonoBehaviour
{
    Player player;
    ProjectileDragging projectileDragging;
    public SpriteRenderer eyesSpriteRenderer;

    public GameObject hole;

	void Awake ()
    {
        player = GameObject.FindObjectOfType<Player>();
        projectileDragging = GameObject.FindObjectOfType<ProjectileDragging>();
        eyesSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        eyesSpriteRenderer.enabled = true;
    }

    void Update ()
    {
        //EyesBlink();

        if (player.playerrb.velocity.magnitude < 1)
        {
            transform.Rotate(Vector3.back);
        }
        else
        {
            //PlayerEye code
            //Vector3 diff = new Vector3(1000, 0, 0) - transform.position;
            Vector3 diff = new Vector3(hole.transform.position.x, hole.transform.position.y, 0) - transform.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }
        
        if (player.playerrb.position.y > 5 && !player.grounded)
        {
            //transform.Rotate(new Vector3(-1000,0,0));
            //transform.rotation = new Vector3(0,0,-1000).);
            transform.eulerAngles = new Vector3(0, 0, 180);
        }

        if (projectileDragging.dragging)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, Input.mousePosition.magnitude);

            //PlayerEye code
            Vector3 diff = new Vector3(projectileDragging.mouseLineEnd.x, projectileDragging.mouseLineEnd.y,0) - transform.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }
    }

    public void EnableEyes()
    {
        eyesSpriteRenderer.enabled = true;
    }

    public void DisableEyes()
    {
        eyesSpriteRenderer.enabled = false;
    }

    /*public void EyesBlink()
    {
        eyesSpriteRenderer.enabled = false;
        new WaitForSecondsRealtime(1);
        eyesSpriteRenderer.enabled = true;
    }*/
}
