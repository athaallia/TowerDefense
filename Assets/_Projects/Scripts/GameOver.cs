using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI rounds;
    public SceneFader sceneFader;



    private void OnEnable()
    {
        rounds.text = PlayerStats.rounds.ToString();
    }



    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }



    public void Menu()
    {
        sceneFader.FadeTo("MainMenu");
    }
}
