using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
    
    public static GameManager Instance { get; private set; }

    public bool IsGamePlaying = false;

    public GameObject PlayerPrefab;
    public Transform PlayerSpawnPoint;
    public GameObject Player;

    public EnemySpawner EnemySpawner;
    public PowerItemSpawner PowerItemSpawner;

    public PlayerData PlayerData;

    public MeshRenderer Map;

    public UIManager UIManager;

    void Start() {
        if (Instance != null && Instance != this) { 
            Destroy(this); 
        } else { 
            Instance = this; 
        } 

        Player = GameObject.Instantiate(PlayerPrefab,PlayerSpawnPoint.position, PlayerSpawnPoint.rotation);
        PlayerData.CurrentPlayerScore = 0;

        Random.InitState(Random.Range(0,15000));
        IsGamePlaying = true;

        UIManager.GameOverPanel.SetActive(false);

        EnemySpawner.enabled = true;
        EnemySpawner.StartSpawning();
        PowerItemSpawner.enabled = true;
        PowerItemSpawner.StartSpawning();
    }

    public void AddPointsToPlayer(int points){
        PlayerData.CurrentPlayerScore += points;
    }

    public void GameOver() {
        IsGamePlaying = false;
        EnemySpawner.enabled = false;
        PowerItemSpawner.enabled = false;

        ClearEnemies();

        ClearPowerItems();

        Destroy(Player);

        if(PlayerData.CurrentPlayerScore > PlayerData.HighScore){
            PlayerData.HighScore = PlayerData.CurrentPlayerScore;
            PlayerData.HighScoreName = PlayerData.PlayerName;
        }

        UIManager.GameOverPanel.SetActive(true);
    }

    public void ClearEnemies(){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies){
            enemy.SetActive(false);
        }
    }

    public void ClearPowerItems(){
        GameObject[] powerItems = GameObject.FindGameObjectsWithTag("PowerItem");
        foreach(GameObject powerItem in powerItems){
            Destroy(powerItem);
        }
    }

    public void RestartGame() {        
        Start();
    }
}