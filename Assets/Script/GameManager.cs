using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class GameManager : MonoBehaviour
{
    internal void gameOver(){
        SceneManager.LoadScene(2);
    }

    internal void QuiteGame(){
        Application.Quit();
    }

    internal void resetGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }

    internal void levelSelection(){
        SceneManager.LoadScene(1);
    }

    internal void nextLevel(){

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex+1);

    }

    internal void getLevel(string levelName){
        SceneManager.LoadScene(levelName);
    }

    
}

