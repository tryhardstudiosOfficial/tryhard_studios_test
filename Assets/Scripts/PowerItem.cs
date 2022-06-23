using UnityEngine;
using UnityEngine.Events;

public class PowerItem : MonoBehaviour {
    
    Player Player;

    public PowerItemData PowerItemData;

    public UnityEvent Action;

    public float Speed = 20f;

    private void Start() {
        Player = GameManager.Instance.Player.GetComponent<Player>();
    }

    void Update() {
        transform.position -= transform.forward * Speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag.Equals("Player")){
            Action.Invoke();
            Player.CurrentPowerItem = PowerItemData;
            Destroy(gameObject);
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.tag.Equals("MapBounds")){
            Destroy(gameObject);
        }
    }

    //Modifier Effects
    public void CleanEnemies(){
        GameManager.Instance.ClearEnemies();
    }

    public void HealPlayer(){
        Player.Lives++;
    }

    public void MakePlayerInvincible(){
        Player.InvincibleTime = 10f;
    }

    public void InvertControls(){
        Player.InvertedControlsTime = 10f;
    }

    public void Anihilate(){
        Player.Lives = Mathf.Max(Player.Lives - 2, 0);
        if(Player.Lives <= 0){
            GameManager.Instance.GameOver();
        }
    }
}