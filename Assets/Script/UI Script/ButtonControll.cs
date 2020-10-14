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
        AudioManager.Instance.Play(Sounds.ButtonClick);
        FindObjectOfType<GameManager>().levelSelection();
    }

    void OnClickQuit(){
        AudioManager.Instance.Play(Sounds.ButtonClick);
        FindObjectOfType<GameManager>().QuiteGame();
    }

    void OnClickPlayAgain(){
        AudioManager.Instance.Play(Sounds.ButtonClick);
        FindObjectOfType<GameManager>().resetGame();
    }

}
