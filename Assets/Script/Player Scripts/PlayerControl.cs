using System.Collections;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    //```````````````````````````````````````````````````````````````````````````````````````
    //```````````````````````````````````````````````````````````````````````````````````````SerializeField
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float speed,jump;
    [SerializeField]
    private ScoreController scoreController;
    [SerializeField]
    private GameOverScreenController gameOver;
    //```````````````````````````````````````````````````````````````````````````````````````
    //```````````````````````````````````````````````````````````````````````````````````````Values
    private bool isCrouch,isGrounded;
    internal bool playerIsDead=false;
    internal int NoKey,NoofLife=3;

    //```````````````````````````````````````````````````````````````````````````````````````
    //```````````````````````````````````````````````````````````````````````````````````````Instances
    private GameManager gameManager;
    private Rigidbody2D rb2d;
    // Two different collider two state i.e standing and croutch
    private PolygonCollider2D pc2d;
    private BoxCollider2D bc2d;
    

    //```````````````````````````````````````````````````````````````````````````````````````
    //```````````````````````````````````````````````````````````````````````````````````````Awake

    void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        pc2d = gameObject.GetComponent<PolygonCollider2D>();
        bc2d = gameObject.GetComponent<BoxCollider2D>();
    }

    //```````````````````````````````````````````````````````````````````````````````````````
    //```````````````````````````````````````````````````````````````````````````````````````Start

    private void Start() {
        gameManager = FindObjectOfType<GameManager>();    
    }

    //```````````````````````````````````````````````````````````````````````````````````````
    //```````````````````````````````````````````````````````````````````````````````````````OnCollisionEnter2d

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag == "Finish" && NoKey == 2)
        {
            gameManager.nextLevel();
        }

        if (collisionInfo.collider.tag == "Ground")
        {
            isGrounded = true;
        }

        if (collisionInfo.collider.tag == "Danger")
        {
            instantKill(3.0f);
        }  

    }

    //```````````````````````````````````````````````````````````````````````````````````````
    //```````````````````````````````````````````````````````````````````````````````````````Death

    internal void killPlayer()
    { 
        if(!playerIsDead){
            if(NoofLife<=1){
                NoofLife--;
                playerIsDead = true;
                StartCoroutine(secondsToWaitFor(3.0f));
            }
            else{
                NoofLife--;
            }  
        }
    }

    private void instantKill(float delay){
        playerIsDead = true;
        NoofLife = 0;
        StartCoroutine(secondsToWaitFor(delay));
    }

    private IEnumerator secondsToWaitFor(float waitTime){
        yield return new WaitForSeconds(waitTime);
        gameOver.PlayerDied();
    }

    //```````````````````````````````````````````````````````````````````````````````````````
    //```````````````````````````````````````````````````````````````````````````````````````Pick Up Key

    internal void pickUpKey()
    {
        NoKey++;
        scoreController.increaseScore(20);
    }

    //```````````````````````````````````````````````````````````````````````````````````````
    //```````````````````````````````````````````````````````````````````````````````````````Player Movement

    void playerMovement(float horizontal, bool vertical)
    {   
        //``````````````````````````````````````````````````````````````````````Run motion
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        Vector3 scale = transform.localScale;
        scale.x = (horizontal < 0) ? -1f * Mathf.Abs(scale.x) : Mathf.Abs(scale.x);
        transform.localScale = scale;

        //`````````````````````````````````````````````````````````````````````Jump motion

        if (vertical)
        {
            if (isGrounded)
            {
                rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
                isGrounded = false; 
            }
        }
    }

    //```````````````````````````````````````````````````````````````````````````````````````
    //```````````````````````````````````````````````````````````````````````````````````````Player Animation   
    void playerAnimation(float horizontal,bool vertical)
    {   
        // Run Animation
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        // Jump Animation
        animator.SetBool("Jump", vertical);

        // Croutch Animation 
        animator.SetBool("Crouch", isCrouch);

        //Death Animation
        animator.SetBool("IsDead",playerIsDead);
    }

    //```````````````````````````````````````````````````````````````````````````````````````
    //```````````````````````````````````````````````````````````````````````````````````````Fixed Update

    void FixedUpdate()
    {
      pc2d.enabled = (isCrouch) ? false : true;
      bc2d.enabled = !pc2d.enabled;
    }

    //```````````````````````````````````````````````````````````````````````````````````````
    //```````````````````````````````````````````````````````````````````````````````````````Update
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        bool vertical = Input.GetKeyDown(KeyCode.Space);
        isCrouch = Input.GetKey(KeyCode.LeftControl);
 
        playerMovement(horizontal, vertical);
        playerAnimation(horizontal, vertical);

        if (transform.position.y < -9)
        {
          instantKill(1.0f);
        }
    }

}

    