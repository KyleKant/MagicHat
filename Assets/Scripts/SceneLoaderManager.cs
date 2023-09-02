using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderManager : MonoBehaviour
{
    public GameObject sceneLoader;

    private const int GUIDE_SCENE = 1;
    public void ChangeScene(int sceneBuildIndex)
    {
        if(sceneLoader != null)
        {
            SceneManager.LoadScene(sceneBuildIndex);
        }
    }
}
