using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    //answers.unity3d.com/questions/387800/click-holddrag-move-camera.html
    CameraFollow camFollow;
    Camera mainCam;

    private Vector3 ResetCamera; // original camera position
    private Vector3 Origin; // place where mouse is first pressed
    private Vector3 Difference; // change in position of mouse relative to origin

    bool panningCam = false;
    bool draggingAim = false;
    Vector3 positionClamped;
    Vector3 mousePos;

    private void Awake()
    {
        camFollow = GameObject.FindObjectOfType<CameraFollow>();
        mainCam = Camera.main;
    }

    void FixedUpdate()
    {
        ResetCamera = mainCam.transform.position;
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            draggingAim = true;
        }
        else
        {
            draggingAim = false;
        }
        /*if (Input.GetMouseButtonUp(0))
        {
            draggingAim = false;
        }*/

            if (Input.GetMouseButtonDown(2) && !draggingAim)
        {
            Origin = MousePos();
        }

        if (Input.GetMouseButton(2) && !draggingAim)
        {
            //panningCam = true;
            positionClamped = new Vector3(Mathf.Clamp(transform.position.x, camFollow.minCameraPos.x, camFollow.maxCameraPos.x), Mathf.Clamp(transform.position.y, camFollow.minCameraPos.y, camFollow.maxCameraPos.y), Mathf.Clamp(transform.position.z, camFollow.minCameraPos.z, camFollow.maxCameraPos.z));
            //transform.position = positionClamped;

            Difference = MousePos() - positionClamped;
            //transform.position = Origin - Difference;
            mainCam.transform.position = Origin - Difference;
        }

        if (Input.GetMouseButtonUp(2)) // reset camera to original position
        {
            transform.position = ResetCamera;
        }
    }

// return the position of the mouse in world coordinates (helper method)
Vector3 MousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}