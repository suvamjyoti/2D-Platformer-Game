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
        gameManager.getLevel(levelName);
    }

}
