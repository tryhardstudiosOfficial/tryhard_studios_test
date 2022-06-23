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

    public string CurrentPlayerName;
    public int CurrentPlayerScore;

    public string HighScoreName;
    public int HighScore;

    public MeshRenderer Map;

    public UIManager UIManager;

    void Awake() {
        if (Instance != null && Instance != this) { 
            Destroy(this); 
        } else { 
            Instance = this; 
        } 

        Player = GameObject.Instantiate(PlayerPrefab,PlayerSpawnPoint.position, PlayerSpawnPoint.rotation);

        Random.InitState(Random.Range(0,15000));
        IsGamePlaying = true;
        EnemySpawner.enabled = true;
        PowerItemSpawner.enabled = true;

        UIManager.GameOverPanel.SetActive(false);
    }

    public void AddPointsToPlayer(int points){
        CurrentPlayerScore += points;
    }

    public void GameOver() {
        Debug.Log("Game Over");
        IsGamePlaying = false;
        EnemySpawner.enabled = false;
        PowerItemSpawner.enabled = false;

        ClearEnemies();

        ClearPowerItems();

        Destroy(Player);

        if(CurrentPlayerScore > HighScore){
            HighScore = CurrentPlayerScore;
            HighScoreName = CurrentPlayerName;
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
        Awake();
    }
}