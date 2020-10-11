using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 Offset;

    private PlayerControl player;

    private void Start() {
        player = FindObjectOfType<PlayerControl>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(!player.playerIsDead){
        transform.position = target.position - Offset;
        }
    }
}
