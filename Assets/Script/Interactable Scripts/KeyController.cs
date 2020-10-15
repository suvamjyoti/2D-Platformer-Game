using UnityEngine;

public class KeyController : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.GetComponent<PlayerControl>() != null)
        {
            PlayerControl playerControl = collisionInfo.gameObject.GetComponent<PlayerControl>();
            AudioManager.Instance.Play(Sounds.pickKey);
            playerControl.pickUpKey();
            Destroy(gameObject);
        }
    }

}
