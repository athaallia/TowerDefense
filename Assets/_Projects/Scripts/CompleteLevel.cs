using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{
    public SceneFader sceneFader;

    public string nextLevel = "Level2";
    public int levelToUnlock = 2;



    public void Continue()
    {
        PlayerPrefs.GetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(nextLevel);
    }



    public void Menu()
    {
        sceneFader.FadeTo("MainMenu");
    }
}
