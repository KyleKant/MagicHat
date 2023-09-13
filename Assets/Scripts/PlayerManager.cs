using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerData playerData;
    public int scoreOfPlayer;
    public int highsScoreOfPlayer;
    private PlayerDataManager playerDataManager;
    private void Start()
    {
        playerDataManager = FindObjectOfType<PlayerDataManager>();
        playerData = playerDataManager.ReadFile("Player Score.json");
        playerData.playerScore = 0;
        highsScoreOfPlayer = playerData.highScore;
    }
}
