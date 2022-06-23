using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    
    Player player;

    public Text PlayerName;
    public Text PlayerScore;
    public Text CurrentPowerItemName;
    public Text CurrentPowerItemDescription;
    public Text CurrentPowerItemTime;
    public Text BulletsLeft;
    public GameObject BulletsReloadingPanel;
    public Text BulletsReloading;
    public Text LivesLeft;

    public GameObject GameOverPanel;
    public Text CurrentName;
    public Text CurrentScore;
    public Text HighScoreName;
    public Text HighScore;

    PlayerData PlayerData;

    void Start() {
        player = GameManager.Instance.Player.GetComponent<Player>();

        PlayerData = GameManager.Instance.PlayerData;

        PlayerName.text = PlayerData.PlayerName;
    }

    void Update() {

        if(GameManager.Instance.IsGamePlaying){
            if(player == null) Start();
            
            PlayerScore.text = PlayerData.CurrentPlayerScore.ToString();
            LivesLeft.text = player.Lives.ToString();
            BulletsLeft.text = player.Shoots.ToString();
            if(player.LastReloadTime < player.ShootReloadTime){
                BulletsReloading.text = player.LastReloadTime.ToString("0.00") + " segundos";
                BulletsReloadingPanel.SetActive(true);
            }else{
                BulletsReloadingPanel.SetActive(false);
            }

            if(player.CurrentPowerItem != null){
                CurrentPowerItemName.text = player.CurrentPowerItem.PowerItemName;
                CurrentPowerItemDescription.text = player.CurrentPowerItem.PowerItemDescription;
                if(player.CurrentPowerItemTime > 0f){
                    CurrentPowerItemTime.text = player.CurrentPowerItemTime.ToString("0.00") + " segundos faltantes";
                }else{
                    CurrentPowerItemTime.text = "";
                }
            }else{
                CurrentPowerItemName.text = "";
                CurrentPowerItemDescription.text = "";
            }
        }else{
            CurrentName.text = PlayerData.PlayerName;
            CurrentScore.text = PlayerData.CurrentPlayerScore.ToString();
            HighScoreName.text = PlayerData.HighScoreName;
            HighScore.text = PlayerData.HighScore.ToString();
        }
    }

    public void BackToMenu(){
        SceneManager.LoadScene("MainScene");
    }
}