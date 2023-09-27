using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderManager : MonoBehaviour
{
    public GameObject sceneLoader;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Debug.Log(audioSource.clip.name);
    }

    public void ChangeScene(int sceneBuildIndex)
    {
        if (this != null)
        {
            audioSource.PlayOneShot(audioSource.clip);
            StartCoroutine(DelayStopAudio(audioSource.clip.length * 0.25f, sceneBuildIndex));
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
