﻿using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerControl : MonoBehaviour
{

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float speed,jump;
    [SerializeField]
    private ScoreController scoreController;

    private bool isCrouch,isDead=false,isGrounded,hasKey;



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
        if (collisionInfo.collider.tag == "Finish" && hasKey)
        {
            SceneManager.LoadScene("Scene2");
        }

        if (collisionInfo.collider.tag == "Ground")
        {
            isGrounded = true;
        }

    }

    internal void pickUpKey()
    {
        hasKey = true;
        scoreController.increaseScore(20);
    }

    void playerMovement(float horizontal, float vertical)
    {   
        // Run actual motion
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        Vector3 scale = transform.localScale;
        scale.x = (horizontal < 0) ? -1f * Mathf.Abs(scale.x) : Mathf.Abs(scale.x);
        transform.localScale = scale;


        // Jump motion
        if (vertical > 0)
        {
            if (isGrounded)
            {
                rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
                isGrounded = false; 
            }
        }
    }

    void playerAnimation(float horizontal,float vertical,bool isCrouch)
    {   
        // Run animation
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        
        // Jump Animation
        bool isJumping = (vertical > 0) ? true : false;
        animator.SetBool("Jump", isJumping);

        // Croutch animation and Collider Resize
        animator.SetBool("Crouch", isCrouch);
    }

    void FixedUpdate()
    {
      pc2d.enabled = (isCrouch) ? false : true;
      bc2d.enabled = (isCrouch) ? true : false;
    }


    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        isCrouch = Input.GetKey(KeyCode.LeftControl);
 
        playerMovement(horizontal, vertical);
        playerAnimation(horizontal, vertical,isCrouch);

        //death condition
        if (transform.position.y < -12 && !(isDead))
        {
            isDead = true;
            FindObjectOfType<GameManager>().resetGame();
        }
    }
}

    