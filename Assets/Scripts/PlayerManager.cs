using System;
using System.Linq;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private int lifeNumber = 3;
    public int Life = 3;
    public delegate void ChangeLifeNumberVariable(int newLifeNumber);
    public static event ChangeLifeNumberVariable OnDecreaseLifeNumberVariable;
    public static event ChangeLifeNumberVariable OnIncreaseLifeNumberVariable;
    public PlayerDataList playerDataList;
    public PlayerData playerData;
    private PlayerDataManager playerDataManager;
    private GameManager gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
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
        if (!CheckPlayerIsLifing())
        {
            lifeNumber = 3;
            gameManager.currentGameState = GameState.GameOver;
        }
        if (Life > lifeNumber)
        {
            if (OnDecreaseLifeNumberVariable != null)
            {
                Life = lifeNumber;
                OnDecreaseLifeNumberVariable(lifeNumber);
            }
        }
        else if (Life < lifeNumber)
        {
            if (OnIncreaseLifeNumberVariable != null)
            {
                Life = lifeNumber;
                OnIncreaseLifeNumberVariable(lifeNumber);
            }
        }
    }
    private void AddPlayerDataToPlayerDataList(int score)
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
    private void PlayerLostOneLife(int lifeLost)
    {
        lifeNumber -= lifeLost;
        if (lifeNumber == 0)
        {
            Debug.Log("Player is die.");
        }
    }
    private void PlayerGetOneLife(int lifeBonus)
    {
        lifeNumber += lifeBonus;
    }
    private void PlayerGetBuffDefuff(int buffOrDebuffIndex)
    {
        switch (buffOrDebuffIndex)
        {
            case 0:
                PlayerGetOneLife(1);
                break;
            case 1:
                AddPlayerDataToPlayerDataList(5);
                break;
            case 2:
                PlayerLostOneLife(1);
                break;
            case 3:
                PlayerLostOneLife(3);
                break;
        }
    }
    public void OnEnable()
    {
        CoinController.OnIncreaseScore += AddPlayerDataToPlayerDataList;
        CoinController.OnLifeLost += PlayerLostOneLife;
        ExplosionController.OnLifeLostDueExplosionBomb += PlayerLostOneLife;
        OwlBlueController.OnPressedOwl += PlayerGetBuffDefuff;
    }
    public int GetLifeNumber()
    {
        return lifeNumber;
    }
    private bool CheckPlayerIsLifing()
    {
        if (lifeNumber > 0)
        {
            return true;
        }
        return false;
    }
}
