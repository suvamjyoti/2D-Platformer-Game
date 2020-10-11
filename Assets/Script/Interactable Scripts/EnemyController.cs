using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float MoveSpeed;

    private bool MoveRight=false;

    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.GetComponent<PlayerControl>() != null)
        {
            PlayerControl playerControl = collisionInfo.gameObject.GetComponent<PlayerControl>(); 
            playerControl.killPlayer();
        }
    }


    void Update()
    {

        if (MoveRight)
        {
            transform.Translate(-MoveSpeed*Time.deltaTime,0,0);
            transform.localScale = new Vector2(-2, 2);
        }
        else
        {
            transform.Translate(MoveSpeed*Time.deltaTime,0,0);
            transform.localScale = new Vector2(2, 2);
        }

    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("turn"))
        {
            MoveRight = !MoveRight;
        }
    }


}
