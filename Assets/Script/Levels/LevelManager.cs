using UnityEngine;


//````````````````````````````````````````````````````````````````````````Singelton Class
//```````````````````````````````````````````````````````````````````````````````````````
public class LevelManager : MonoBehaviour
{
    private static LevelManager instance=null;
    public static LevelManager Instance{get{return instance;}}
    [SerializeField]
    private string Level1;
    private GameManager gameManager;

    //````````````````````````````````````````````````````````````````````````Awake Class
    //````````````````````````````````````````````````````````````````````````````````````
    private void Awake() {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    //````````````````````````````````````````````````````````````````````````Start Class
    //````````````````````````````````````````````````````````````````````````````````````
    private void Start() {
        if(GetLevelStatus(Level1)==LevelStatus.Locked){             //initially Level1 Unlocked
            SetLevelStatus(Level1,LevelStatus.Unlocked);
        }

        gameManager = FindObjectOfType<GameManager>();

    }

    //````````````````````````````````````````````````````````````````````````````````````
    //````````````````````````````````````````````````````````````````````````````````````

    internal void SetCurrentLevelComplete(){
        SetLevelStatus(gameManager.getCurrentSceneName(),LevelStatus.Completed);    //Set Current Level Complete
        SetLevelStatus(gameManager.getNextSceneName(),LevelStatus.Unlocked);        //Set Next Level Unlocked 
    }

    //````````````````````````````````````````````````````````````````````````````````````
    //````````````````````````````````````````````````````````````````````````````````````

    internal LevelStatus GetLevelStatus(string levelName){

        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(levelName,0);
        return levelStatus;
    }

    //````````````````````````````````````````````````````````````````````````````````````
    //````````````````````````````````````````````````````````````````````````````````````
    internal void SetLevelStatus(string levelName, LevelStatus levelStatus){
        
        PlayerPrefs.SetInt(levelName,(int)levelStatus);                                    //unity function to store value locally
    }
}
