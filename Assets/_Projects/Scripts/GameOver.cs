using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI rounds;



    private void OnEnable()
    {
        rounds.text = PlayerStats.rounds.ToString();
    }



    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



    public void Menu()
    {
        Debug.Log("Go To Menu");
    }
}
