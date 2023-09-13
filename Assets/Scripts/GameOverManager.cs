using TMPro;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerScore;
    [SerializeField] private TextMeshProUGUI highScore;
    private PlayerDataManager playerDataManager;
    private PlayerData playerData;
    private void Start()
    {
        playerDataManager = FindObjectOfType<PlayerDataManager>();
        playerData = playerDataManager.ReadFile("Player Score.json");
        playerScore.text = $"Your Score: {playerData.playerScore}";
        highScore.text = $"High Score: {playerData.highScore}";
    }
}
