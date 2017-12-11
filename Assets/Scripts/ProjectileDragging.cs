using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDragging : MonoBehaviour
{
    Player player;
    GameGUI gameGui;

    private LineRenderer mouseLine;
    public Rigidbody2D rb;
    Camera mainCamera;

    public float mouseLaunchSpeed;
    //float launchForceMax = 1000;
    public bool outOfShots = false;

    Vector2 mouseStart;
    Vector2 mouseEnd;
    public Vector2 mouseLaunchDirection;
    //[Range(0f, 100f)] private float mouseLaunchDirectionMagnitude;

    public Vector2 mouseLineStart;
    public Vector2 mouseLineEnd;

    Vector3 mousePosition;

    public Color minMouseLineColor;
    public Color maxMouseLineColor;
    Color whiteClear = new Color(1, 1, 1, 0);
    Color whiteClearAlpha = new Color(1, 1, 1, 0.5f);

    //TrajectoryPath trajectoryPath;
    public bool dragging = false;
    public bool updateTrajectory = false;
    public bool dragCancel = false;
    public float dist;
    public Vector2 launchForce; // Used for trajectoryPath.
    public Vector2 launchVectorNew;

    public GameObject dot;

    //Sound Effects
    private AudioSource source;
    public AudioClip golfPutt;
    public AudioClip golfSwingSoft;
    public AudioClip golfSwing;

    void Awake()
    {
        player = GameObject.FindObjectOfType<Player>(); //NEEDED?
        gameGui = GameObject.FindObjectOfType<GameGUI>();

        //launchForceMax = launchForce.magnitude;

        source = GetComponent<AudioSource>();
    }

    void Start ()
    {
        mainCamera = Camera.main;
        LineRendererSetup();
        //mouseLaunchDirectionMagnitude = mouseLaunchDirection.magnitude;
    }

    void LineRendererSetup()
    {
        mouseLine = GetComponent<LineRenderer>();
        //mouseLine.SetPosition(0, mousePosition); //CHECK
        //mouseLine.SetPosition(1, mousePosition); //CHECK
        mouseLine.startWidth = 0.5f;
        mouseLine.endWidth = 0.5f;
        mouseLine.startColor = whiteClearAlpha;
        //mouseLine.useWorldSpace = false; //Allows CameraFollow to function although it is not perfect! Removed to fix Drag Aim Collider position not following player
        mouseLine.enabled = false;

        //transform.position = mainCamera.transform.position; //Fix to Camera
        transform.position = new Vector3(player.playerrb.position.x, player.playerrb.position.y, mainCamera.nearClipPlane); //Fix to Player
    }

    void Update ()
    {

        /*if (launchForce.magnitude > launchForceMax)
        {
            launchForce.magnitude = launchForceMax;
        }*/

        //Debug.Log(launchForce.magnitude);
        //Debug.Log(mouseLaunchDirection.magnitude);
        //mouseLaunchDirectionMagnitude = mouseLaunchDirection.magnitude;

        //Line Colour (Moved from FixedUpdate)
        //mouseLine.startColor = minMouseLineColor;
        //mouseLine.endColor = maxMouseLineColor;
        mouseLine.endColor = Color.blue;
        //maxMouseLineColor = Color.Lerp(maxMouseLineColor, minMouseLineColor, mouseLaunchDirection.magnitude);
        //mouseLine.endColor = Color.Lerp(minMouseLineColor, maxMouseLineColor, mouseLaunchDirection.magnitude/100);
        mouseLine.endColor = Color.Lerp(minMouseLineColor, maxMouseLineColor, Vector3.Distance(mouseLineStart, mouseLineEnd)/10); //Lerp based on the length of MouseLine, /10 to get answer between 0 & 1.

        //Drag Cancel / Safe Exit Mode (Moved from FixedUpdate)
        if (dist < 1)
        {
            dragCancel = true;
            mouseLine.endColor = whiteClear; //signifies safe cancel / exit mode.
                                             //mouseLine.startColor = new Color (1,1,1,0);
                                             //mouseLine.enabled = false;
        }
        else
        {
            dragCancel = false;
        }

        if (Input.GetMouseButton(1))
        {
            dragging = false;
            updateTrajectory = false;
            mouseLine.enabled = false;
        }

        //sand bunker 50% power penalty
        if (player.inBunker)
        {
            //launchForce = launchForce / 2;
            mouseLaunchSpeed = 2.5f;
        }
        else
        {
            mouseLaunchSpeed = 5f; //CHANGE IF MOUSELAUNCHSPEED EVER CHANGES!!!
        }

        if (player.curShots == 0)
        {
            outOfShots = true;
        }

    }

    void FixedUpdate()
    {
        //transform.position = player.playerrb.transform.position; //Fix to Player
        transform.position = new Vector3(player.playerrb.position.x, player.playerrb.position.y, mainCamera.nearClipPlane); //Fix to Player

        mousePosition = Input.mousePosition;
        //mousePosition = mainCamera.ScreenPointToRay(Input.mousePosition).origin;
        mousePosition.z = mainCamera.nearClipPlane;


        //launchForce = mouseLaunchDirection * mouseLaunchSpeed;

        /*if (updateTrajectory)
        {
            //Vector2 currentPosition = dot.transform.position;
            //Vector2 currentPosition = GameObject.Find("dot(Clone)").transform.position;
            //Vector2 directionVector = mouseLaunchDirection.magnitude * player.playerrb.velocity;
            //Vector2 currentPosition = player.playerrb.position + directionVector;
            //Vector2 currentPosition = transform.position + mouseLaunchDirection;
            //Vector2 currentPosition = player.playerrb.position;
            //Vector2 currentPosition = player.playerrb.position;
            //Vector2 currentPosition = mouseLaunchDirection;
            Vector2 currentposition = player.playerrb.position;

            //Vector2 dotPos = player.playerrb.position.x, mouseLaunchDirection.normalized;
            //Vector2 dotPosition = new Vector2(player.playerrb.position + (mouseLaunchDirection * mouseLaunchSpeed));

            Vector2[] arrayOfPoints;
            //arrayOfPoints = Plot(player.playerrb, player.playerrb.position, launchForce, 5);
            //arrayOfPoints = Plot(dot.GetComponent<Rigidbody2D>(), currentposition, launchForce, 10);
            arrayOfPoints = Plot(player.playerrb, currentposition, launchForce, 10);

            //Create Object
            foreach (Vector2 point in arrayOfPoints)
            {
                Instantiate(dot, point, Quaternion.identity);
            }
        }*/



        //DEL? screenpoint/world testing
        //transform.position = Vector3.MoveTowards(transform.position, mainCamera.transform.position, 1 * Time.deltaTime);

        //Vector2 worldtoScreenHack = new Vector2(player.playerrb.position.x, transform.position.y);
        //transform.position = Vector3.MoveTowards(transform.position, worldtoScreenHack, 10 * Time.deltaTime);

        //Vector3 sum = transform.position + mainCamera.transform.position;
        //transform.InverseTransformVector (sum);
        //transform.tra(sum);
        //transform.position = Vector3.MoveTowards(transform.position, mainCamera.transform.position, 1 * Time.deltaTime);
        //mouseLine.transform.InverseTransformVector(mouseLineStart);

        //Aimer World>Screen Fix that unintentionally fixes to ball when in front and stays stationary if behind which gives a nice effect.

        mouseLineStart = Vector2.MoveTowards(mouseLineStart, player.playerrb.position, player.playerrb.velocity.magnitude * Time.deltaTime);
        //mouseLineEnd = Vector2.MoveTowards(mouseLineEnd, player.playerrb.position, player.playerrb.velocity.magnitude * Time.deltaTime); //Removed to keep LineEnd tied to mouse position.
    }

    private void LateUpdate()
    {
        //transform.Translate.mousePosition = transform.position + mainCamera.transform.position;

        //transform.position = transform.position + Camera.main.WorldToViewportPoint(transform.position);
    }

    void OnMouseDown()
    {
        //print(mainCamera.ScreenPointToRay(Input.mousePosition).origin);

        if (player.grounded && !outOfShots)
        {
            //mouseLine.enabled = true; //Deleted to avoid jumping Linerenderer when spawning a new line.
            updateTrajectory = true;
            dragging = true;
            mouseStart = mousePosition;
            //mouseLineStart = mainCamera.ScreenToWorldPoint(mouseStart)
            mouseLineStart = mainCamera.ScreenPointToRay(Input.mousePosition).origin;

            //transform.position = Vector3.MoveTowards(transform.position, worldtoScreenHack, 10 * Time.deltaTime);
            //mouseLineStart = Vector2.MoveTowards(mouseLineStart, player.playerrb.position, 10 * Time.deltaTime);


            //mouseLine.transform.InverseTransformVector(mouseLineStart);

            //Vector2 mouseLineStartO = Camera.main.WorldToViewportPoint(gameObject.transform.position);
            //mouseLineStart = Camera.main.WorldToViewportPoint(mouseLineStart);
            //mouseLine.transform.InverseTransformPoint(mainCamera.ScreenToWorldPoint(mouseLine.transform.position));
            //mouseLineStart = new Vector2(0,0);
            //transform.position = Vector3.MoveTowards(transform.position, posVec, speed * Time.deltaTime);

        }
    }

    void OnMouseDrag()
    {
        //dragging = true;
        //updateTrajectory = true;

        //if (player.grounded && updateTrajectory)
        if (player.grounded && dragging && !outOfShots)
        {
            //dragging = true;
            //updateTrajectory = true;
            mouseLine.enabled = true; //Enabled in Drag to avoid jumping Linerenderer when spawning a new line.
            mouseEnd = mousePosition;

            mouseLaunchDirection = mouseStart - mouseEnd;
            //mouseLaunchDirection = Vector3.ClampMagnitude((mouseStart - mouseEnd), 100f); //Clamps the force but not the line renderer.

            //Vector3.ClampMagnitude(mouseLaunchDirection, 100f);
            //Mathf.Clamp(mouseLaunchDirection.magnitude, 0f, 100f);

            //mouseLineEnd = mainCamera.ScreenToWorldPoint(mouseEnd);
            mouseLineEnd = mainCamera.ScreenPointToRay(mouseEnd).origin;


            //Vector3 dir = endPos - startPos;
            dist = Mathf.Clamp(Vector3.Distance(mouseLineStart, mouseLineEnd), 0, 10); //MouseLine Length
            mouseLineEnd = mouseLineStart - (mouseLaunchDirection.normalized * dist);
            //Debug.Log("mouseLaunchDirection.normalized * dist = " + mouseLaunchDirection.normalized * dist);

            //float dist = Vector3.Distance(mouseStart, mouseEnd);
            //Debug.Log(dist);

            mouseLine.positionCount = 2;
            mouseLine.SetPosition(0, mouseLineStart);
            mouseLine.SetPosition(1, mouseLineEnd);

            launchVectorNew = (mouseLaunchDirection.normalized * dist);
            launchForce = Vector3.ClampMagnitude(mouseLaunchDirection, 800) * mouseLaunchSpeed;
            //launchForce = Vector3.ClampMagnitude(launchForce, 2000);

            //Debug.Log("mld" + mouseLaunchDirection.magnitude);
            //Debug.Log(launchForce);

            //launchForce = launchVectorNew * mouseLaunchSpeed;

            //Debug.Log("mouse launch direction = " + mouseLaunchDirection);
            //Debug.Log("mouse launch speed = " + mouseLaunchSpeed);
            //Debug.Log("launchForce = " + launchForce);

            /*if (updateTrajectory)
            {
                Vector2[] arrayOfPoints;
                arrayOfPoints = Plot(player.playerrb, player.playerrb.position, launchForce, 5);

                //Create Object
                foreach (Vector2 point in arrayOfPoints)
                {
                    Instantiate(dot, point, Quaternion.identity);
                }
            }*/
        }

        //Plot(player.playerrb, player.playerrb.position, launchForce, 10);
        //Debug.Log(Plot(player.playerrb, player.playerrb.position, launchForce, 10));

        /*Vector2[] arrayOfPoints;
        arrayOfPoints = Plot(player.playerrb, player.playerrb.position, launchForce, 100);

        //Create Object
        foreach (Vector2 point in arrayOfPoints)
        {
        Instantiate(dot, point, Quaternion.identity);
        }*/

        //Create Object Vector3 method 
        //foreach (Vector2 point in arrayOfPoints)
        //{
            //Vector3 convertedPosition = new Vector3(point.x, point.y, 0); //Then convert vector 2 to three, you will have to consult your points printed in console
            //Instantiate(dot, convertedPosition, Quaternion.identity);
        //}
    }

        void OnMouseUp()
    {
        mouseLine.enabled = false;
        mouseLine.SetPosition(0, Vector3.zero); //Resets Line to nothing to stop it jumping on new Line creation.
        mouseLine.SetPosition(1, Vector3.zero); //Resets Line to nothing to stop it jumping on new Line creation.
        dragging = false;
        //updateTrajectory = false;

        //sand bunker 50% power penalty
        /*if (player.inBunker)
        {
            launchForce = launchForce / 2;
        }*/

        if (player.grounded && updateTrajectory && !dragCancel && !outOfShots)
        {
            //Debug.Log(mouseLaunchDirection);
            //Debug.Log("MLDR.MAGNITUDE = " + mouseLaunchDirection.magnitude);
            //Debug.Log("dist = " + Vector3.Distance(mouseLineStart, mouseLineEnd));
            //Debug.Log("launch force = " + launchForce);
            //Debug.Log("launch force.normalized = " + launchForce.normalized);
            //Debug.Log("launch force.magnitude = " + launchForce.magnitude);
            //Debug.Log("MLDM" + mouseLaunchDirectionMagnitude);
            //launchForce = mouseLaunchDirection * mouseLaunchSpeed;
            rb.AddForce(launchForce);
            Debug.Log(launchForce.magnitude);
            if (launchForce.magnitude > 100) //FIXES UNINTENTIONAL SHOTS WHEN USING UI/OPTIONS
            {
                player.ShotTaken();
            }

            //Sound Effects
            if (launchForce.magnitude > 100 && launchForce.magnitude < 1000) //FIXES UNINTENTIONAL SHOTS WHEN USING UI/OPTIONS
            {
                source.clip = golfPutt;
                source.volume = 1f;
                source.Play();
            }
            if (launchForce.magnitude >= 1000 && launchForce.magnitude < 2000) //FIXES UNINTENTIONAL SHOTS WHEN USING UI/OPTIONS
            {
                source.clip = golfSwingSoft;
                source.volume = 1f;
                source.Play();
            }
            if (launchForce.magnitude >= 2000) //FIXES UNINTENTIONAL SHOTS WHEN USING UI/OPTIONS
            {
                source.clip = golfSwing;
                source.volume = 0.5f;
                source.Play();
            }

            //Debug.Log(mouseLaunchDirection * mouseLaunchSpeed);    
        }

    }

    private void OnMouseOver()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //print(ray.origin);

        //if (ray)

        /*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray))
        {
            Debug.Log("click");
            print(gameObject.name);
        }

        if (gameObject.tag == "Player")
        {
            Debug.Log("UI Hover");
            mousePosition = Input.mousePosition;
        }*/
    }

    public static Vector2[] Plot(Rigidbody2D rigidbody, Vector2 pos, Vector2 velocity, int steps)
    {
        //rigidbody = player.playerrb;
        //pos = player.playerrb.position;
        //velocity = launchForce;

        Vector2[] results = new Vector2[steps];

        float timestep = Time.fixedDeltaTime / Physics2D.velocityIterations;
        //Vector2 gravityAccel = Physics2D.gravity * rigidbody.gravityScale * timestep * timestep;
        Vector2 gravityAccel = Physics2D.gravity;
        //float drag = 1f - timestep * rigidbody.drag;
        float drag = 0; // Fixed misalignment issue away from play RB position.
        Vector2 moveStep = velocity * timestep;

        for (int i = 0; i < steps; ++i)
        {
            moveStep += gravityAccel;
            moveStep *= drag;
            pos += moveStep;

            //Debug.Log(pos);
            //Instantiate(dot, pos);

            results[i] = pos;
        }

        return results;
    }
}