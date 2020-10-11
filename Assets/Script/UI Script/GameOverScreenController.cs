using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreenController : MonoBehaviour
{
    internal void PlayerDied()
    {
        Debug.Log("levle lelvel");
        gameObject.SetActive(true);        
    }

}
