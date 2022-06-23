using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainTitleUI : MonoBehaviour {

    public PlayerData PlayerData;
    public GameObject ControlsPanel;

    public Text PlayerName;

    void Awake(){
        ControlsPanel.SetActive(false);

        PlayerName.text = PlayerData.PlayerName;
        PlayerData.PlayerName = "";
    }

    public void StartGame() {
        PlayerData.PlayerName = PlayerName.text;
        SceneManager.LoadScene("GameScene");
    }

    public void ExitGame() {
        Application.Quit();
    }
}
