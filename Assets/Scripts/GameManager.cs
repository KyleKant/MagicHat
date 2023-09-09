using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameOver = false;
    public bool isGamePaused = false;
    public bool isGamePlaying = true;
    private const int GAMEOVER_SCENE = 3;
    private SceneLoaderManager sceneLoader;
    private DataStorageController dataStorageController;
    private PlayerManager playerManager;
    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoaderManager>();
        dataStorageController = FindObjectOfType<DataStorageController>();
        playerManager = FindObjectOfType<PlayerManager>();
    }
    private void Update()
    {
        Debug.Log(isGameOver);
        if (isGameOver)
        {
            dataStorageController.WriteObject("Player Score.dat", playerManager.scoreOfPlayer, playerManager.highScoreOfPlayer);
            sceneLoader.ChangeScene(GAMEOVER_SCENE);
            //Destroy(this.gameObject);
        }
    }
}
