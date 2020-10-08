﻿using System.Collections;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float speed,jump;
    [SerializeField]
    private ScoreController scoreController;

    private bool isCrouch,isGrounded,playerIsDead=false;
    private int NoKey;


    private Rigidbody2D rb2d;
    // Two different collider two state i.e standing and croutch
    private PolygonCollider2D pc2d;
    private BoxCollider2D bc2d;

    void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        pc2d = gameObject.GetComponent<PolygonCollider2D>();
        bc2d = gameObject.GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag == "Finish" && NoKey == 2)
        {
            FindObjectOfType<GameManager>().startGame();
        }

        if (collisionInfo.collider.tag == "Ground")
        {
            isGrounded = true;
        }

        if (collisionInfo.collider.tag == "Danger")
        {
            killPlayer();
        }  

    }

    //```````````````````````````````````````````````````````````````````````````````````````
    //```````````````````````````````````````````````````````````````````````````````````````
    //Death
    //```````````````````````````````````````````````````````````````````````````````````````
    //```````````````````````````````````````````````````````````````````````````````````````
    
    internal void killPlayer()
    { 
        if(!playerIsDead){
            playerIsDead = true;
            speed=0;
            jump=0;
            StartCoroutine(secondsToWaitFor(3.0f));  
        }
    }

    private IEnumerator secondsToWaitFor(float waitTime){
        yield return new WaitForSeconds(waitTime);
        FindObjectOfType<GameManager>().gameOver();
    }

    //```````````````````````````````````````````````````````````````````````````````````````
    //```````````````````````````````````````````````````````````````````````````````````````
    //pickUp Key
    //```````````````````````````````````````````````````````````````````````````````````````
    //```````````````````````````````````````````````````````````````````````````````````````
    

    internal void pickUpKey()
    {
        NoKey++;
        scoreController.increaseScore(20);
    }

    //```````````````````````````````````````````````````````````````````````````````````````
    //```````````````````````````````````````````````````````````````````````````````````````
    //player Movement
    //```````````````````````````````````````````````````````````````````````````````````````
    //```````````````````````````````````````````````````````````````````````````````````````
    

    void playerMovement(float horizontal, bool vertical)
    {   
        // Run actual motion
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        Vector3 scale = transform.localScale;
        scale.x = (horizontal < 0) ? -1f * Mathf.Abs(scale.x) : Mathf.Abs(scale.x);
        transform.localScale = scale;


        // Jump motion
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
    //```````````````````````````````````````````````````````````````````````````````````````
    //Animation
    //```````````````````````````````````````````````````````````````````````````````````````
    //```````````````````````````````````````````````````````````````````````````````````````
    
    void playerAnimation(float horizontal,bool vertical,bool isCrouch)
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

    void FixedUpdate()
    {
      pc2d.enabled = (isCrouch) ? false : true;
      bc2d.enabled = (isCrouch) ? true : false;
    }


    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        bool vertical = Input.GetKeyDown(KeyCode.Space);
        isCrouch = Input.GetKey(KeyCode.LeftControl);
 
        playerMovement(horizontal, vertical);
        playerAnimation(horizontal, vertical,isCrouch);

        if (transform.position.y < -12)
        {
          killPlayer();
        }
    }
}

    