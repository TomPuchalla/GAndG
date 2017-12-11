using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderBallPath : MonoBehaviour
{
    private LineRenderer lineRenderer;
    Player player; //Added
    ProjectileDragging projectileDragging;

    public float initialVelocity = 0; //Original = 0
    float timeResolution = 0.02f; //Viewable in Project Setting > Time > Fixed Timestep
    float maxTime = 3f; //Original = 0.3f
    //int maxDots = 10; //Original = 30

    Vector2 initalVectorDirection;

    //LineRender Dots
    public LineTextureMode textureMode = LineTextureMode.Tile;
    public float tileAmount = 1.0f;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        player = GameObject.FindObjectOfType<Player>();
        projectileDragging = GameObject.FindObjectOfType<ProjectileDragging>();
    }

    void Start ()
    {
        lineRenderer.enabled = false;
	}

    void FixedUpdate() //FixedUpdate?
    {
        if (projectileDragging.dragging && player.grounded)
        {
            lineRenderer.enabled = true;
            //initialVelocity = Shoot.currentLaunchForce / Shoot.currentBall.mass; //Added //Real-time ballistic path using /mass. (F = M*A) > (A = v/t= F/M) > (V = A*t) > final equation = (F = (M*A)*t)
            //initialVelocity = projectileDragging.launchForce.magnitude / player.playerrb.mass;

            //Vector2 velocityVector = projectileDragging.launchForce;//transform.forward * initialVelocity;
            //Vector2 velocityVector = projectileDragging.mouseLaunchDirection;//transform.forward * initialVelocity;

            int index = 0;
            //lineRenderer.SetVertexCount((int)(maxTime / timeResolution)); //Original. SetVertexCount depreciated and replaced by 'numPositions'.

            //int index = 0; //Move above lineRenderer.SetVertexCount/numPositions to fix outofbounds error?

            lineRenderer.positionCount = ((int)(maxTime / timeResolution));

            Vector2 currentPosition = player.playerrb.position;
            //Vector2 currentPosition = transform.position; //TESTING (allows line to stay at origin to check path against ball at start.

            //Vector3 currentRotation = Vector3.forward;

            //If statement added to fix nullreference exception and 'Assertion failed on expression', possibly due to equation diving by mass which = 0 if null.
            {
                //initialVelocity = Shoot.currentLaunchForce / Shoot.currentBall.mass; //Added //Real-time ballistic path using /mass. (F = M*A) > (A = v/t= F/M) > (V = A*t) > final equation = (F = (M*A)*t) Move above initialVelocity to fix OutofBounds error?
                //initialVelocity = projectileDragging.mouseLaunchDirection.magnitude/100 / player.playerrb.mass;
                //initialVelocity = projectileDragging.launchForce.magnitude / 10000; // player.playerrb.mass;
                //initialVelocity = projectileDragging.launchVectorNew.magnitude / player.playerrb.mass;
            }

            //initialVelocity = projectileDragging.mouseLaunchDirection.magnitude / player.playerrb.mass;

            initalVectorDirection = projectileDragging.mouseLaunchDirection / player.playerrb.mass;

            initalVectorDirection = Vector3.ClampMagnitude(projectileDragging.mouseLaunchDirection, 800) / player.playerrb.mass;

            //Vector2 velocityVector = initialVelocity * projectileDragging.mouseLaunchDirection;
            //Vector2 velocityVector = initialVelocity * projectileDragging.mouseLaunchDirection/1000 / projectileDragging.mouseLaunchSpeed;
            Vector2 velocityVector = initalVectorDirection * projectileDragging.mouseLaunchSpeed / 50.5f; //INCREASE NUMBER TO DECREASE LINE RENDER LENGTH

            //if (Shoot.currentLaunchForce == 0)
            //{
            //lineRenderer.enabled = false;
            //}

            //if (Shoot.currentLaunchForce >= 1)
            //{
            //lineRenderer.enabled = true;
            //}

            //lineRenderer.SetColors(c, green);

            //lineRenderer.material.SetFloat("maxTime", maxDots);

            for (float t = 0.0f; t < maxTime; t += timeResolution)
            {
                lineRenderer.SetPosition(index, currentPosition);
                currentPosition += velocityVector * timeResolution; //*currentBallMass;
                velocityVector += Physics2D.gravity * timeResolution;

                //float distance = Vector2.Distance(transform.position,currentPosition);
                lineRenderer.textureMode = textureMode;
                //lineRenderer.material.SetTextureScale("_MainTex", new Vector2(distance/10, 1.0f));
                lineRenderer.material.SetTextureScale("_MainTex", new Vector2(2, 1.0f)); // 1/4 of Line size for perfect circle?
                ++index;

                /*if (hit.collider)
                {
                    Debug.Log("Raycast Hit");
                    lineRenderer.SetPosition(index, hit.point);
                }*/

                //edgeCol2D.points = lineRenderer.GetPositions(i);
                //edgeCol2D.points = velocityVector.t;

                //BallPathColor();
            }

            //lineRenderer.startColor = Color.Lerp(Color.clear, Color.white, Vector3.Distance(projectileDragging.mouseLineStart, projectileDragging.mouseLineEnd) / 100); //Lerp based on the length of MouseLine, /10 to get answer between 0 & 1.
            lineRenderer.endColor = Color.clear;
            lineRenderer.startColor = Color.Lerp(Color.clear, Color.white, Vector3.Distance(projectileDragging.mouseLineStart, projectileDragging.mouseLineEnd) / 10); //Lerp based on the length of MouseLine, /10 to get answer between 0 & 1. //15 gives good number for Trajectory Path alpha

            //LineRender Dots
            //lineRenderer.material.SetTextureScale("circle-white", new Vector2(2 * 2, 1));
            //lineRenderer.material.SetTextureOffset("circle-white", new Vector2(Time.timeSinceLevelLoad * 4f, 0f));
            //lineRenderer.material.SetTextureScale("circle-white", new Vector2(index, 10f));

        }

        else
        {
            lineRenderer.enabled = false;
        }           
    }
}