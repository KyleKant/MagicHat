using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderManager : MonoBehaviour
{
    public GameObject sceneLoader;

    public void ChangeScene(int sceneBuildIndex)
    {
        if (sceneLoader != null)
        {
            SceneManager.LoadScene(sceneBuildIndex);
        }
    }
}
