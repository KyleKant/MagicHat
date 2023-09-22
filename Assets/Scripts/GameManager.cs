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
    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoaderManager>();
        playerDataManager = FindObjectOfType<PlayerDataManager>();
        playerManager = FindObjectOfType<PlayerManager>();
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
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

}
public enum GameState
{
    Play,
    Pause,
    GameOver
}
