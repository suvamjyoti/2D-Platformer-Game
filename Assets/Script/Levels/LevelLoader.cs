using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    Button button;
    [SerializeField]private string levelName;

    private GameManager gameManager;


    private void Awake() {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);        
    }

    private void Start() {
        gameManager = FindObjectOfType<GameManager>();
        
    }

    private void OnClick(){
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(levelName);      //GetLevelStatus

        switch(levelStatus){
            case LevelStatus.Locked:                    //Locked
                Debug.Log("Level Locked");
                break;

            case LevelStatus.Unlocked:                  //Unlocked
                AudioManager.Instance.Play(Sounds.ButtonClick);
                gameManager.getLevel(levelName);        
                break;

            case LevelStatus.Completed:                 //Completed
                AudioManager.Instance.Play(Sounds.ButtonClick);
                gameManager.getLevel(levelName);
                break;
        }

    }

}
