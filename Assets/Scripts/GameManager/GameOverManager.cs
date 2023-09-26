using System.Linq;
using TMPro;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerScore;
    [SerializeField] private TextMeshProUGUI highScore;
    private PlayerDataManager playerDataManager;
    private PlayerDataList playerDataList;
    private PlayerManager playerManager;
    private void Start()
    {
        playerDataManager = FindObjectOfType<PlayerDataManager>();
        playerManager = FindObjectOfType<PlayerManager>();
        playerDataList = playerDataManager.ReadFile("Player Score.json");
        int highestScore = playerDataList.PlayerDatas.Max(playerData => playerData.highScore);
        playerScore.text = $"Your Score: {playerManager.playerDataList.PlayerDatas.Last().playerScore}";
        highScore.text = $"High Score: {highestScore}";
    }
}
