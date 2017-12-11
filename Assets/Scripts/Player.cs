using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    ProjectileDragging projectileDragging;

    public GameObject holeEnterExit;
    public Animator transitionHole;
    public Animation holeIn;
    public GameObject hole;
    //GameObject hole;
    //Flag Animation
    public Animator holeFlag;
    public Animation flag;

    //ScoreUpdate
    public bool holeFinish = false;
    public int holeScore;
    float finalShotRest = 0.05f;
    
    //Effects
    public ParticleSystem fireworks;
    public ParticleSystem waterSplash;
    public ParticleSystem sandSplash;

    private TrailRenderer trailRenderer;

    public float moveSpeed = 10f;
    public float jumpSpeed = 10f;
    public Rigidbody2D playerrb;
    public Collider2D playerCollider;
    public CircleCollider2D ccol2d;

    //Shots/Health
    public int curShots;
    public int maxShots;

    //Levels Scores
    public int level1Score;
    public int level2Score;
    public int level3Score;
    public int level4Score;
    public int level5Score;
    public int level6Score;
    public int level7Score;

    public bool grounded = false;
    public LayerMask groundLayer;
    public float groundCheckRadius;
    public bool inBunker = false;

    SpriteRenderer spriteRenderer;
    public Sprite golfHappy;
    public Sprite golfLong;
    public Sprite golfOhSmall;
    public Sprite golfOhBig;
    public Sprite golfDead;
    public Sprite golfBig;

    //Eyes
    public PlayerEyes[] playerEyes;
    public PlayerEyes playerEyesGO;
    public SpriteRenderer eyesRenderer;

    //Sound Effects
    private AudioSource source;
    //public AudioClip swing;
    //public AudioClip holeSound;
    public AudioClip fireworksSound;
    public AudioClip bouncy;
    public AudioClip splash;

    public AudioClip[] enemyHit;

    void Awake()
    {
        projectileDragging = GameObject.FindObjectOfType<ProjectileDragging>();

        playerEyes = GameObject.FindObjectsOfType<PlayerEyes>();
        //playerEyes = GetComponentsInChildren<PlayerEyes>();
        playerEyesGO = GameObject.FindObjectOfType<PlayerEyes>();
        eyesRenderer = GetComponentInChildren<SpriteRenderer>();

        playerrb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        ccol2d = GetComponent<CircleCollider2D>();

        trailRenderer = GetComponent<TrailRenderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        //Sound Effects
        source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        spriteRenderer.sprite = golfHappy;
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = golfHappy;

        //SET MAXSHOTS AT BEGINNING OF EACH LEVEL
        //maxShots = 10;
        curShots = maxShots;
    }

    void Update()
    {
        if (curShots < 0)
        {
            curShots = 0;
        }

        if (curShots < 0)
        {
            Die();
        }

        /*if (inBunker)
        {
            finalShotRest = 0f;
        }
        if (!inBunker && curShots <= 0 && projectileDragging.outOfShots && (playerrb.velocity.magnitude) <= finalShotRest && !holeFinish)
        {
            Die();
        }*/

        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Big Mode");
            transform.localScale = new Vector3(2, 2, 2);
            //playerCollider.ci transform.localScale = new Vector3(2, 2, 2);
            ccol2d.radius = 1;
            groundCheckRadius = 2.5f;
            //playerCollider.transform.localScale = new Vector2(2,2);
            //playerrb.mass = 5;
            //trailRenderer.startWidth = Mathf.Clamp((playerrb.velocity.magnitude * Time.deltaTime), 1, 3);
            //spriteRenderer.sprite = golfBig;
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            playerrb.mass = 2.5f;
            ccol2d.radius = 0.5f;
            groundCheckRadius = 1;
        }

        if (playerrb.velocity.magnitude < 10)
        {
            spriteRenderer.sprite = golfHappy;
        }

        if (playerrb.velocity.magnitude > 10)
        {
            spriteRenderer.sprite = golfLong;
        }

        if (playerrb.transform.position.y > 3)
        {
            spriteRenderer.sprite = golfOhSmall;
        }

        if (playerrb.transform.position.y > 3 && playerrb.velocity.magnitude > 10)
        {
            spriteRenderer.sprite = golfOhBig;
        }

        if (playerrb.transform.localScale == new Vector3(2, 2, 2))
        {
            spriteRenderer.sprite = golfBig;
            //playerCollider.transform.collider2D transform.localScale = new Vector3 (2,2,2);
            trailRenderer.startWidth = Mathf.Clamp((playerrb.velocity.magnitude * Time.deltaTime), 1, 3);
        }

        if (playerrb.transform.position.y < -10)
        {
            Die();
        }

        foreach (PlayerEyes playerEyes in playerEyes)
        {
            if (playerrb.transform.position.y < -3 && playerrb.transform.localScale == new Vector3(1, 1, 1))
            {
                playerEyes.eyesSpriteRenderer.enabled = false;
                playerEyes.DisableEyes();
                spriteRenderer.sprite = golfDead;
            }
            else
            {
                playerEyes.EnableEyes();
            }
        }
        
        /*if (curShots > maxShots)
        {
            curShots = maxShots
        }*/

        //eyeTest.transform.position = Vector2.MoveTowards(eyeTest.transform.position, new Vector2(1000, 0),0.01f);

        //playerrb.transform.LookAt(new Vector3(1000, 0));
        //Vector3 testerino = new Vector3 (playerrb.transform.position.x, playerrb.transform.position.y, 0);
        //eyeTest.transform.LookAt(playerrb.transform.worldToLocalMatrix);
        //eyeTest.transform.eulerAngles = new Vector3(0, 0, 90); //eyeTest.transform.eulerAngles.z
        //eyeTest.transform.rotation = Quaternion.RotateTowards(transform.rotation, testerino, 360);
        //.SetLookRotation(playerrb.position);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, step);

        /*Vector3 vectorToTarget = targetTransform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);*/

        /*Vector2 vectorToTarget = playerrb.transform.position - eyeTest.transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        eyeTest.transform.rotation = Quaternion.Slerp(eyeTest.transform.rotation, q, Time.deltaTime * 5);*/

        /*Vector2 vectorToTarget = playerrb.transform.position - eyeTest.transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        //float angle = new Vector2(vectorToTarget.x, vectorToTarget.y).magnitude;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        eyeTest.transform.rotation = Quaternion.Slerp(eyeTest.transform.rotation, q, Time.deltaTime * 10);*/

        /*Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - eyeTest.transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        eyeTest.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);*/

        //PlayerEye code
        /*Vector3 diff = new Vector3(1000,0,0) - playerEye.transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        playerEye.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);*/

        //eyeTest.transform.RotateAround(eyeTest.transform.position, new Vector3(0, 0, 1), 45);

        /*Vector2 current = transform.position;
            var direction = target - current;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);*/

        /*Vector3 dir = playerrb.transform.position - eyeTest.transform.position;
        dir = playerrb.transform.InverseTransformDirection(dir);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        eyeTest.transform.eulerAngles = new Vector3(0, 0, angle+60);*/
    }

    void FixedUpdate()
    {
        //isGrounded = false;
        //grounded = Physics2D.Linecast(transform.position, transform.position, 1 << LayerMask.NameToLayer("Ground"));
        grounded = Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayer);
        TrailRenderer();

        //movement left and right
        /*if (Input.GetKey(KeyCode.RightArrow))
            //transform.Translate(new Vector2(1, 0) * moveSpeed * Time.deltaTime);
            playerrb.AddForce(Vector2.right * jumpSpeed, ForceMode2D.Force);
        if (Input.GetKey(KeyCode.LeftArrow))
            //transform.Translate(new Vector2(-1, 0) * moveSpeed * Time.deltaTime);
            playerrb.AddForce(Vector2.left * jumpSpeed, ForceMode2D.Force);*/

        //Debug.Log(playerrb.velocity.magnitude);
    }

    //Used for checking if the player is touching the ground 
    /*void OnCollisionStay2D(Collision2D coll) // C#, type first, name in second
    {
        if (grounded == true && (Input.GetKey(KeyCode.UpArrow)))
        {
            playerrb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            Debug.Log("Collision with ground");
        }
    }*/

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            source.clip = enemyHit[Random.Range(0, enemyHit.Length)];
            source.Play();
        }
        
        /*if (collision.collider.tag == "Enemy")
        {
            //StartCoroutine(EyesCollisionDisable());
            foreach (PlayerEyes playerEyes in playerEyes)
            {
                //playerEyes.GetComponent<SpriteRenderer>().enabled = false;
                playerEyes.DisableEyes();
                //playerEyes.DisableEyes();
            }
        }*/

        if (collision.collider.tag == "Sand")
        {
            //Debug.Log("Bunker");
            inBunker = true;
            playerrb.angularDrag = 10;

            //Sand Splash Effect
            {
                //Debug.Log("Sand Splash");
                Instantiate(sandSplash, transform.position, Quaternion.identity);
                sandSplash.Play(true);
            }
        }
        else
        {
            inBunker = false;
            playerrb.angularDrag = 1;
        }

        if (collision.gameObject.tag == "Bouncy")
        {
            source.clip = bouncy;
            source.Play();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!inBunker && curShots == 0 && playerrb.velocity.magnitude <= finalShotRest && !holeFinish)
        {
            Die();
        }

        if (inBunker && curShots == 0 && playerrb.velocity.magnitude == 0 && !holeFinish)
        {
            Debug.Log("hit bunker");
            Die();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == hole)
        { 
            StartCoroutine(HoleFinish());
        }

        //Water Splash Effect
        if (collision.gameObject.tag == "Water")
        {
            Instantiate(waterSplash, transform.position, Quaternion.identity);
            waterSplash.Play(true);

            //Sound Effect
            source.clip = splash;
            source.Play();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        //Water Splash Effect
        if (collision.gameObject.tag == "Water")
        {
            Instantiate(waterSplash, transform.position, Quaternion.identity);
            waterSplash.Play(true);
        }
    }

    /*void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            Debug.Log("Grounded");
        }
        else
        {
            grounded = false;
            Debug.Log("NOT Grounded");
        }
    }*/

    void TrailRenderer()
    {

        //if (playerrb.velocity >= 100f)
        //{
        //trailRenderer.enabled = true;
        //}

        //trailRenderer.endColor = Color.Lerp(Color.green, Color.red, playerrb.velocity.x/100);
        trailRenderer.startColor = Color.Lerp(Color.clear, Color.white, playerrb.velocity.magnitude * Time.deltaTime);
        trailRenderer.startWidth = Mathf.Clamp((playerrb.velocity.magnitude * Time.deltaTime),0.5f,1.5f);
        //trailRenderer.endWidth = Mathf.Clamp((playerrb.velocity.magnitude / 10), 0.5f, 1);
    }

    public void Die()
    {
        //Debug.Log("You died");
        curShots -= 1;
        
        //Restart
        Application.LoadLevel(Application.loadedLevel);
        //SceneManager.LoadScene(Find.loadedScene)
    }

    public void ShotTaken()
    {
        //Debug.Log("Shot taken");
        curShots -= 1; 
    }

    IEnumerator HoleFinish()
    {
        holeFinish = true;
        holeScore = maxShots - curShots;

        //Sound Effects
        //source.clip = holeSound;
        //source.Play();
        source.clip = fireworksSound;
        source.Play();

        //Score Update
        print(SceneManager.GetActiveScene().buildIndex);

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Level1Score();
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Level2Score();
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            Level3Score();
        }
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            Level4Score();
        }
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            Level5Score();
        }
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            Level6Score();
        }

        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            Level7Score();
        }

        fireworks.Play(true);
        holeFlag.Play("HoleFlagTop");

        yield return new WaitForSeconds(5);

        transitionHole.Play("HoleIn");
        
        //anim.PlayQueued("shoot", QueueMode.PlayNow);

        yield return new WaitForSeconds(2);

        //Update score for main menu?, level unlocks etc.

        //Debug.Log("Back to Menu");

        Application.LoadLevel(0);
    }

    /*IEnumerator EyesCollisionDisable()
    {
        foreach (PlayerEyes playerEyes in playerEyes)
        {
            //GetComponentInChildren<SpriteRenderer>().enabled = false;
            //playerEyesGO.DisableEyes();
            playerEyesGO.GetComponent<SpriteRenderer>().enabled = false;
            spriteRenderer.sprite = golfDead;
            yield return new WaitForSeconds(200);
            //GetComponentInChildren<SpriteRenderer>().enabled = true;
            playerEyesGO.GetComponent<SpriteRenderer>().enabled = true;


            //playerEyes.DisableEyes();
            //spriteRenderer.sprite = golfDead;
            //yield return new WaitForSeconds(2);
            //playerEyes.EnableEyes();
        }
        //yield return new WaitForSeconds(2);
    }*/

    //transitionHole.Play("HoleIn");

    /*public void HoleInAnim()
    {
        Debug.Log("HOLE IN!!!");
    }*/



    //Level Scores

    public void Level1Score()
    {
        level1Score = holeScore;

        if (holeScore > 0 && holeScore < PlayerPrefs.GetInt("Level1BestScore", 100))
        //if (level1Score > 0)
        //{
            //if (level1Score < PlayerPrefs.GetInt("Level1BestScore", 0))
            {
                PlayerPrefs.SetInt("Level1BestScore", holeScore);
            }
        //}
    }
            //if (level1Score < PlayerPrefs.GetInt("Level1BestScore", 0) && level1Score > 0)

    public void Level2Score()
    {
        level2Score = holeScore;

        if (holeScore > 0 && holeScore < PlayerPrefs.GetInt("Level2BestScore", 100))
        {
            PlayerPrefs.SetInt("Level2BestScore", holeScore);
        }
    }

    public void Level3Score()
    {
        level3Score = holeScore;

        if (holeScore > 0 && holeScore < PlayerPrefs.GetInt("Level3BestScore", 100))
        {
            PlayerPrefs.SetInt("Level3BestScore", holeScore);
        }
    }

    public void Level4Score()
    {
        level4Score = holeScore;

        if (holeScore > 0 && holeScore < PlayerPrefs.GetInt("Level4BestScore", 100))
        {
            PlayerPrefs.SetInt("Level4BestScore", holeScore);
        }
    }

    public void Level5Score()
    {
        level5Score = holeScore;

        if (holeScore > 0 && holeScore < PlayerPrefs.GetInt("Level5BestScore", 100))
        {
            PlayerPrefs.SetInt("Level5BestScore", holeScore);
        }
    }

    public void Level6Score()
    {
        level6Score = holeScore;

        if (holeScore > 0 && holeScore < PlayerPrefs.GetInt("Level6BestScore", 100))
        {
            PlayerPrefs.SetInt("Level6BestScore", holeScore);
        }
    }

    public void Level7Score()
    {
        level7Score = holeScore;

        if (holeScore > 0 && holeScore < PlayerPrefs.GetInt("Level7BestScore", 100))
        {
            PlayerPrefs.SetInt("Level7BestScore", holeScore);
        }
    }
}