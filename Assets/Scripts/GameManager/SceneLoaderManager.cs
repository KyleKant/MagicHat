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
        audioSource = GetComponent<AudioSource>();
        gameManager = FindObjectOfType<GameManager>();
        Debug.Log(gameManager.name);
    }

    public void ChangeScene(int sceneBuildIndex)
    {
        if (gameManager.currentGameState == GameState.Play)
        {
            if (this != null)
            {
                audioSource.PlayOneShot(audioSource.clip);
                StartCoroutine(DelayStopAudio(audioSource.clip.length * 0.25f, sceneBuildIndex));
            }
        }
        else if (gameManager.currentGameState == GameState.GameOver)
        {
            StartCoroutine(DelayStopAudio(1f, sceneBuildIndex));
        }
    }
    private IEnumerator DelayStopAudio(float seconds, int sceneBuildIndex)
    {
        yield return new WaitForSeconds(seconds);
        if (sceneLoader != null)
        {
            SceneManager.LoadScene(sceneBuildIndex);
        }
    }
}
