using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameOver = false;
    public bool isGamePaused = false;
    public bool isGamePlaying = true;
    private const int GAMEOVER_SCENE = 3;
    private SceneLoaderManager sceneLoader;
    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoaderManager>();
    }
    private void Update()
    {
        Debug.Log(isGameOver);
        if (isGameOver)
        {
            sceneLoader.ChangeScene(GAMEOVER_SCENE);
            //Destroy(this.gameObject);
        }
    }
}
