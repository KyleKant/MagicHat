using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    private const int GUIDE_SCENE = 1;
    private void Update()
    {
        ChangeSplashSceneToGuideScene();
    }
    private void ChangeSplashSceneToGuideScene()
    {
        if (Application.isPlaying)
        {
            Debug.Log(Application.isPlaying);
        }
    }
    private void OnMouseDown()
    {
        if (Application.isPlaying)
        {
            Debug.Log("clicked mouse");
            SceneManager.LoadScene(GUIDE_SCENE);
        }
    }
}
