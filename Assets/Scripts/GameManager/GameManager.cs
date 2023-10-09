using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState gameState;
    public GameState currentGameState;
    public bool isGamePlaying = true;
    private const string GAMEOVER_SCENE = "Gameover";
    private SceneLoaderManager sceneLoader;
    [SerializeField] private PlayerDataManager playerDataManager;
    [SerializeField] private PlayerManager playerManager;
    private GameDataManager gameDataManager;
#pragma warning disable IDE0090 // Use 'new(...)'
    private GameData gameData = new GameData();
#pragma warning restore IDE0090 // Use 'new(...)'
    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoaderManager>();
        //playerDataManager = FindObjectOfType<PlayerDataManager>();
        //playerManager = FindObjectOfType<PlayerManager>();
        gameDataManager = this.gameObject.AddComponent<GameDataManager>();
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
                //Debug.Log("Game is GameOver");
                //ChangeSceneToGameOverScene();
                break;
        }
    }
    private void ChangeSceneToGameOverScene()
    {
        Debug.Log("Game is GameOver");
        if (playerManager != null)
        {
            if (playerManager.playerData != null)
            {
                playerManager.playerDataList.PlayerDatas.Add(playerManager.playerData);
            }
        }
        playerDataManager.WriteFile("Player Score.json", playerManager.playerDataList);
        sceneLoader.ChangeScene(GAMEOVER_SCENE);
    }
    private void OnEnable()
    {
        PlayerManager.OnGameStateChanged += PlayerManager_OnGameStateChanged;
    }

    private void PlayerManager_OnGameStateChanged(GameState gameState)
    {
        ChangeSceneToGameOverScene();
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
    public GameData ReadGameData()
    {
        if (gameData != null)
        {
            gameData = gameDataManager.ReadFile("GameData.json");
        }
        else
        {
            Debug.Log("gameData is null");
        }
        return gameData;
    }
    public void ExitGame()
    {
        Debug.Log("Exit game");
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
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
