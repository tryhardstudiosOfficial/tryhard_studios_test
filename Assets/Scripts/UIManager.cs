using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    
    Player player;

    public Text PlayerName;
    public Text PlayerScore;
    public Text CurrentPowerItemName;
    public Text CurrentPowerItemDescription;
    public Text CurrentPowerItemTime;
    public Text BulletsLeft;
    public Text LivesLeft;

    public GameObject GameOverPanel;
    public Text CurrentName;
    public Text CurrentScore;
    public Text HighScoreName;
    public Text HighScore;

    //Tiempo para mostar el power up si no tiene duracion
    float defaultShownTime = 2f;
    float currentShowTime = 0f;

    void Start() {
        player = GameManager.Instance.Player.GetComponent<Player>();

        PlayerName.text = GameManager.Instance.CurrentPlayerName;
    }

    void Update() {

        if(GameManager.Instance.IsGamePlaying){
            if(player == null) Start();
            
            PlayerScore.text = GameManager.Instance.CurrentPlayerScore.ToString();
            LivesLeft.text = player.Lives.ToString();
            BulletsLeft.text = player.Shoots.ToString();

            if(player.CurrentPowerItem != null && currentShowTime <= Mathf.Max(defaultShownTime, player.CurrentPowerItem.PowerItemDuration)){
                CurrentPowerItemName.text = player.CurrentPowerItem.PowerItemName;
                CurrentPowerItemDescription.text = player.CurrentPowerItem.PowerItemDescription;
                CurrentPowerItemTime.text = player.CurrentPowerItem.PowerItemDuration + " segundos faltantes";
            }
        }else{
            CurrentName.text = GameManager.Instance.CurrentPlayerName;
            CurrentScore.text = GameManager.Instance.CurrentPlayerScore.ToString();
            HighScoreName.text = GameManager.Instance.HighScoreName;
            HighScore.text = GameManager.Instance.HighScore.ToString();
        }
    }
}