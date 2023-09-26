using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState gameState;
    public GameState currentGameState;
    public bool isGamePlaying = true;
    private const int GAMEOVER_SCENE = 3;
    private SceneLoaderManager sceneLoader;
    private PlayerDataManager playerDataManager;
    private PlayerManager playerManager;
    private GameDataManager gameDataManager;
    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoaderManager>();
        playerDataManager = FindObjectOfType<PlayerDataManager>();
        playerManager = FindObjectOfType<PlayerManager>();
        gameDataManager = GetComponent<GameDataManager>();
    }
    private void Update()
    {
        switch (currentGameState)
        {
            case GameState.Play:
                Debug.Log("Game is Playing");
                break;
            case GameState.Pause:
                Debug.Log("Game is Pausing");
                break;
            case GameState.GameOver:
                ChangeSceneToGameOverScene();
                break;
        }
    }
    private void ChangeSceneToGameOverScene()
    {
        playerManager.playerDataList.PlayerDatas.Add(playerManager.playerData);
        playerDataManager.WriteFile("Player Score.json", playerManager.playerDataList);
        sceneLoader.ChangeScene(GAMEOVER_SCENE);
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        currentGameState = GameState.Pause;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        currentGameState = GameState.Play;
    }
    public void ReadGameData()
    {
        GameData gameData = gameDataManager.ReadFile("GameData.json");
        Debug.Log(gameData.Level + "//" + gameData.State);
    }
}
[JsonConverter(typeof(StringEnumConverter))]
public enum GameState
{
    [EnumMember(Value = "Play")]
    Play,
    [EnumMember(Value = "Pause")]
    Pause,
    [EnumMember(Value = "GameOver")]
    GameOver,
}
[JsonConverter(typeof(StringEnumConverter))]
public enum GameLevel
{
    [EnumMember(Value = "Easy")]
    Easy,
    [EnumMember(Value = "Normal")]
    Normal,
    [EnumMember(Value = "Hard")]
    Hard,
}
