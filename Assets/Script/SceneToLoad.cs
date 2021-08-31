using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneToLoad : MonoBehaviour
{
    public enum Scenes
    {
        Environment,
        ZoomIn
    }

    public Scenes NextScene;

    public void LoadNextScene()
    {
        switch (NextScene)
        {
            case Scenes.Environment:
                SceneManager.LoadScene(0);
                break;
            case Scenes.ZoomIn:
                SceneManager.LoadScene(1);
                break;
        }
    }
}
