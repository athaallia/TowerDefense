using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver = false;

    public GameObject gameOverUI;



    private void Start()
    {
        gameIsOver = false;
    }



    private void Update()
    {
        if (gameIsOver)
            return;

        if (Input.GetKeyDown(KeyCode.E))
            EndGame();

        if (PlayerStats.lives <= 0)
            EndGame();
    }



    private void EndGame()
    {
        gameIsOver = true;
        gameOverUI.SetActive(true);
    }
}
