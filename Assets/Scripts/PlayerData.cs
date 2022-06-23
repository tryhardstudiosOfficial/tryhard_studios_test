using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 2)]
public class PlayerData : ScriptableObject {
    
    public string PlayerName = "";
    public int CurrentPlayerScore = 0;

    public string HighScoreName;
    public int HighScore;

}