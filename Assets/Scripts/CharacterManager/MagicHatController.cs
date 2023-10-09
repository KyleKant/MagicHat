using System.Collections.Generic;
using UnityEngine;

public class MagicHatController : MonoBehaviour
{
    private const int SCORE_LIMIT = 5;
    [SerializeField] private float respawnTime = 0.5f;
#pragma warning disable IDE0090 // Use 'new(...)'
    [SerializeField] private List<GameObject> gameObjects = new List<GameObject>();
#pragma warning restore IDE0090 // Use 'new(...)'
    [SerializeField] private GameObject respawnPoint;
    private float increaseTime = 0f;
#pragma warning disable IDE0044 // Add readonly modifier
#pragma warning disable IDE0090 // Use 'new(...)'
    private Dictionary<int, GameObject> keyValuePairs = new Dictionary<int, GameObject>();
#pragma warning restore IDE0090 // Use 'new(...)'
#pragma warning restore IDE0044 // Add readonly modifier
    private GameManager gameManager;
#pragma warning disable IDE0090 // Use 'new(...)'
    private GameData gameData = new GameData();
#pragma warning restore IDE0090 // Use 'new(...)'
    private PlayerManager playerManager;
    private PlayerData playerData;
    private string level = "";
    public int scoreLimitIncreaseTimesNum = 1;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        playerManager = FindObjectOfType<PlayerManager>();
        for (int index = 0; index < gameObjects.Count; index++)
        {
            keyValuePairs.Add(index, gameObjects[index]);
        }
        gameData = gameManager.ReadGameData();
        //Debug.Log(gameData.Level);
    }
    private void Update()
    {
        if (gameManager.currentGameState == GameState.Play)
        {
            playerData = playerManager.playerData;
            if (respawnTime > 1f && playerData.playerScore > SCORE_LIMIT * scoreLimitIncreaseTimesNum)
            {
                scoreLimitIncreaseTimesNum += 1;
                respawnTime -= 0.5f;
            }
            switch (gameData.Level)
            {
                case GameLevel.Easy:
                    level = "Easy";
                    break;
                case GameLevel.Normal:
                    level = "Normal";
                    break;
                case GameLevel.Hard:
                    level = "Hard";
                    break;
                default:
                    break;
            }
            if (level == "Easy")
            {
                Debug.Log("You are at the Easy Level");
                if (Time.time > increaseTime)
                {
                    int randomKey = GetRandomNum(0, gameObjects.Count);
                    GameObject respawnObject = GetRandomRespawnObject(keyValuePairs, randomKey);
                    Respawn(respawnObject, respawnPoint);
                    increaseTime = Time.time + respawnTime;
                }
            }
            else if (level == "Normal")
            {
                Debug.Log("You are at the Normal Level");
                if (Time.time > increaseTime)
                {
                    //GameObject randomRespawnPoint = new();
                    int randomKey = GetRandomNum(0, gameObjects.Count);
                    GameObject respawnObject = GetRandomRespawnObject(keyValuePairs, randomKey);
                    respawnObject.transform.SetPositionAndRotation(new(Random.Range(-3, 3), -4f, -1f), new(0f, 0f, 0f, 0f));
                    Respawn(respawnObject, respawnObject);
                    increaseTime = Time.time + respawnTime;
                }
            }
            else if (level == "Hard")
            {
                Debug.Log("You are at the Hard Level");
                if (Time.time > increaseTime)
                {
                    //GameObject randomRespawnPoint = new();
                    int randomKey = GetRandomNum(0, gameObjects.Count);
                    GameObject respawnObject = GetRandomRespawnObject(keyValuePairs, randomKey);
                    respawnObject.transform.SetPositionAndRotation(new(Random.Range(-3, 3), Random.Range(-4f, 0f), -1f), new(0f, 0f, 0f, 0f));
                    Respawn(respawnObject, respawnObject);
                    increaseTime = Time.time + respawnTime;
                }
            }
            else
            {
                Debug.Log("You haven't chosen a level yet.");
            }
        }
    }
    private int GetRandomNum(int minNum, int maxNum)
    {
        int randomNum = Random.Range(minNum, maxNum);
        return randomNum;
    }
    private GameObject GetRandomRespawnObject(Dictionary<int, GameObject> respawnObjectDict, int randomKey)
    {
        GameObject randomRespawnObject = respawnObjectDict[randomKey];
        return randomRespawnObject;
    }
    private void Respawn(GameObject respawnObject, GameObject respawnPoint)
    {
        Vector3 position = respawnPoint.transform.position;
        Quaternion rotation = respawnPoint.transform.rotation;
        Instantiate(respawnObject, position, rotation);
    }
}
