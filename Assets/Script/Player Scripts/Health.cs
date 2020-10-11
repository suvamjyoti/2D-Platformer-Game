using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{

    private PlayerControl player;
    [SerializeField]
    private Image[] hearts;

    private void Start() {
        player = FindObjectOfType<PlayerControl>();
    }

    void Update()
    {
        for(int i=0;i<hearts.Length;i++){
            if(i<player.NoofLife){
                hearts[i].enabled = true;
            }
            else{
                hearts[i].enabled = false;
            }
            
        }
        
        
    }
}
