using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isEnded = false;
   
    private void Update()
    {
        if (isEnded)
            return;

        if (PlayerStats.lives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        isEnded = true;
        Debug.Log("Game Over!");
    }
}
