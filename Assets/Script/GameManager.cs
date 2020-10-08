using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class GameManager : MonoBehaviour
{
    internal void gameOver(){
        SceneManager.LoadScene(1);
    }

    internal void QuiteGame(){
        Application.Quit();
    }

    internal void startGame()
    {
        SceneManager.LoadScene(0);
    }
}

