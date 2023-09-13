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
        Debug.Log(isGameOver);
        if (isGameOver)
        {
            playerDataManager.WriteFile("Player Score.json", playerManager.playerData);
            sceneLoader.ChangeScene(GAMEOVER_SCENE);
            //Destroy(this.gameObject);
        }
    }
}
