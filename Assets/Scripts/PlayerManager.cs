using System;
using System.Linq;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerDataList playerDataList;
    public PlayerData playerData;
    private PlayerDataManager playerDataManager;

    private void Start()
    {
        playerDataManager = FindObjectOfType<PlayerDataManager>();
        playerDataList = playerDataManager.ReadFile("Player Score.json");
        if (playerDataList.PlayerDatas.Count == 0)
        {
            playerData.playerScore = 0;
            playerData.highScore = 0;
            playerData.dateTime = "0";
            playerDataList.PlayerDatas.Add(playerData);
            playerDataManager.WriteFile("Player Score.json", playerDataList);
        }
    }
    private void Update()
    {
        playerDataList = playerDataManager.ReadFile("Player Score.json");
    }
    public void AddPlayerDataToPlayerDataList(int score)
    {
        playerDataList = playerDataManager.ReadFile("Player Score.json");
        if (playerDataList.PlayerDatas.Count > 0)
        {
            int highestScore = playerDataList.PlayerDatas.Max(playerData => playerData.highScore);
            playerData.playerScore += score;
            if (playerData.playerScore > highestScore)
            {
                playerData.highScore = playerData.playerScore;
                playerData.dateTime = DateTime.Now.ToString("dd/MM/yy hh:mm tt");
            }
        }
    }
    public void OnEnable()
    {
        CoinController.OnIncreaseScore += AddPlayerDataToPlayerDataList;
    }
}
