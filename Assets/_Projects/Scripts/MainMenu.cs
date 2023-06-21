using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SceneFader sceneFader;
    public string levelToLoad;

    

    public void Play()
    {
        sceneFader.FadeTo(levelToLoad);
    }



    public void Quit()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }
}
