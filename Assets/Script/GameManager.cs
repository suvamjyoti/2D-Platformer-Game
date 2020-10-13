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

    internal string getCurrentSceneName(){
        return SceneManager.GetActiveScene().name;
    }

    //```````````````````````````````````````Load next scene and return name of next scene
    //````````````````````````````````````````````````````````````````````````````````````
    internal string getNextSceneName(){
        int nextSceneBuildIndex = SceneManager.GetActiveScene().buildIndex+1;
        SceneManager.LoadScene(nextSceneBuildIndex); 
        Scene scene = SceneManager.GetSceneByBuildIndex(nextSceneBuildIndex);
        return scene.name;
    }

    //`````````````````````````````````````````````````````````````Load a particular level
    //````````````````````````````````````````````````````````````````````````````````````
    internal void getLevel(string levelName){
        SceneManager.LoadScene(levelName);
    }

    
}

