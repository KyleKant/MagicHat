using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderManager : MonoBehaviour
{
    public GameObject sceneLoader;
    private AudioSource audioSource;
    private GameManager gameManager;
    private void Start()
    {
        audioSource = FindObjectOfType<ButtonSound>().GetComponent<AudioSource>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void ChangeScene(string sceneBuild)
    {
        if (gameManager.currentGameState == GameState.Play)
        {
            if (this != null)
            {
                audioSource.PlayOneShot(audioSource.clip);
                StartCoroutine(DelayStopAudio(audioSource.clip.length * 0.25f, sceneBuild));
            }
        }
        else if (gameManager.currentGameState == GameState.GameOver)
        {
            if (this != null)
            {
                StartCoroutine(DelayStopAudio(.5f, sceneBuild));
            }
        }
    }
    private IEnumerator DelayStopAudio(float seconds, string sceneBuild)
    {
        yield return new WaitForSeconds(seconds);
        if (sceneLoader != null)
        {
            int sceneBuildIndex = sceneBuild switch
            {
                "Splash" => 0,
                "Guide" => 1,
                "Gameplay" => 2,
                "Gameover" => 3,
                _ => 0,
            };
            SceneManager.LoadScene(sceneBuildIndex);
        }
    }
}
