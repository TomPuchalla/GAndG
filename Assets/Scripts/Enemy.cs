using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //hole block fix
    //public GameObject hole;
    
    //Effects
    public ParticleSystem waterSplash;
    public ParticleSystem sandSplash;

    private TrailRenderer trailRenderer;

    //public float moveSpeed = 10f;
    //public float jumpSpeed = 10f;
    public Rigidbody2D enemyrb;
    public Collider2D enemyCollider;

    public bool inBunker = false;

    SpriteRenderer spriteRenderer;
    public Sprite goblinHappy;
    public Sprite goblkinLong;
    public Sprite goblinOhSmall;
    public Sprite goblinOhBig;
    public Sprite goblinDead;
    //public Sprite goblinBig;

    public Sprite goblinKingBig;

    //Eyes
    public GoblinEyes[] goblinEyes;
    //public GoblinEyes goblinEyesGO;

    void Awake()
    {
        //goblinEyes = GameObject.FindObjectsOfType<GoblinEyes>();

        goblinEyes = GetComponentsInChildren<GoblinEyes>();
        //goblinEyes = GetComponents<GoblinEyes>();
        //GameObject.FindObjectsOfType<GoblinEyes>();
        enemyrb = GetComponent<Rigidbody2D>();
        enemyCollider = GetComponent<Collider2D>();
        trailRenderer = GetComponent<TrailRenderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        //goblinEyesGO = GetComponent<GoblinEyes>();
    }

    private void Start()
    {
        spriteRenderer.sprite = goblinHappy;
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = goblinHappy;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            StartCoroutine(EyesCollisionDisable());
            //foreach (GoblinEyes goblinEyes in enemyrb.GetComponents<GoblinEyes>())
            //{
                //goblinEyes.DisableEyes();
            //}
        }
    }

    //Hole block fix
    /*private void OnTriggerEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject == hole)
        {
            Debug.Log("Goblin in the hole");
            Destroy(gameObject);
        }

        if (collision.collider.gameObject.tag == "Finish")
        {
            Debug.Log("Goblin in the hole2");
            Destroy(gameObject);
        }
    }*/

    IEnumerator EyesCollisionDisable()
    {
        foreach (GoblinEyes goblinEyes in goblinEyes)
        {
            goblinEyes.DisableEyes();
            spriteRenderer.sprite = goblinDead;
            Debug.Log("this is read eyes");
            yield return new WaitForSeconds(0.5f);
            goblinEyes.EnableEyes();
        }
    }
}