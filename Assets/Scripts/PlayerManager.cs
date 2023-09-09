using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int scoreOfPlayer;
    public int highScoreOfPlayer;
    private DataStorageController storageController;
    private Player player;
    private void Start()
    {
        storageController = FindObjectOfType<DataStorageController>();
        player = storageController.ReadObject("Player Score.dat");
        highScoreOfPlayer = player.highScore;
        Debug.Log($"scoreOfPlayer: {scoreOfPlayer}, highScoreOfPlayer: {highScoreOfPlayer}");
    }
}
