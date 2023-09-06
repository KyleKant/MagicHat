using UnityEngine;

public class GameOverController : MonoBehaviour
{
    private const int GAMEOVER_SCENE = 3;
    private SceneLoaderManager sceneLoader;
    private GameManager gameManager;
    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoaderManager>();
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        if (gameManager.isGameOver)
        {
            sceneLoader.ChangeScene(GAMEOVER_SCENE);
            Destroy(this.gameObject);
        }
    }
}
