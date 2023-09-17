using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameOver = false;
    public bool isGamePaused = false;
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
        if (isGameOver)
        {
            playerManager.playerDataList.PlayerDatas.Add(playerManager.playerData);
            playerDataManager.WriteFile("Player Score.json", playerManager.playerDataList);
            sceneLoader.ChangeScene(GAMEOVER_SCENE);
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        isGamePaused = true;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isGamePaused = false;
    }
    public void SetGamePause()
    {
        isGamePaused = true;
    }
    public void ResetGamePause()
    {
        isGamePaused = false;
    }
}
