using UnityEngine;
using UnityEngine.UI;
public class ButtonControll : MonoBehaviour
{
    [SerializeField]
    private Button playButton,quitButton,playAgainButton;
    

    void Start()
    {
        playButton.onClick.AddListener(OnClickPlay);
        quitButton.onClick.AddListener(OnClickQuit);
        playAgainButton.onClick.AddListener(OnClickPlayAgain);
    }

    void OnClickPlay(){
        FindObjectOfType<GameManager>().startGame();
    }

    void OnClickQuit(){
        FindObjectOfType<GameManager>().QuiteGame();
    }

    void OnClickPlayAgain(){
        FindObjectOfType<GameManager>().startGame();
    }

}
