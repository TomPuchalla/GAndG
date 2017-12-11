using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinEyes : MonoBehaviour
{
    Player player;
    Enemy enemy;
    ProjectileDragging projectileDragging;
    SpriteRenderer goblinEyesSpriteRenderer;

    void Awake()
    {
        player = GameObject.FindObjectOfType<Player>();
        enemy = GetComponent<Enemy>();
        projectileDragging = GameObject.FindObjectOfType<ProjectileDragging>();
        goblinEyesSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        goblinEyesSpriteRenderer.enabled = true;
    }

    void Update()
    {
            //GoblinEye track player code
            //transform.rotation = Quaternion.Euler(0f, 0f, player.playerrb.position.magnitude);

            Vector3 diff = new Vector3(player.playerrb.position.x, player.playerrb.position.y, 0) - transform.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        if (projectileDragging.dragging)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, Input.mousePosition.magnitude);

            //GoblinEye track mouse position code
            Vector3 diff2 = new Vector3(projectileDragging.mouseLineEnd.x, projectileDragging.mouseLineEnd.y, 0) - transform.position;
            diff2.Normalize();
            float rot_z2 = Mathf.Atan2(diff2.y, diff2.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z2 - 90);
        }
    }

    public void EnableEyes()
    {
        goblinEyesSpriteRenderer.enabled = true;
    }

    public void DisableEyes()
    {
        goblinEyesSpriteRenderer.enabled = false;
    }
}
