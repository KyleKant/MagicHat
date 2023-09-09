using TMPro;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerScore;
    [SerializeField] private TextMeshProUGUI highScore;
    private DataStorageController dataStorageController;
    private Player player;
    private void Start()
    {
        dataStorageController = FindObjectOfType<DataStorageController>();
        player = dataStorageController.ReadObject("Player Score.dat");
        playerScore.text = $"Your Score: {player.playerScore}";
        highScore.text = $"High Score: {player.highScore}";
    }
}
