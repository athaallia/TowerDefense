using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RoundsSurvived : MonoBehaviour
{
    public TextMeshProUGUI roundsText;
    public SceneFader sceneFader;



    private void OnEnable()
    {
        StartCoroutine(AnimateText());
    }



    IEnumerator AnimateText()
    {
        roundsText.text = "0";
        int round = 0;

        yield return new WaitForSeconds(0.5f);

        while (round < PlayerStats.rounds)
        {
            round++;
            roundsText.text = round.ToString();

            yield return new WaitForSeconds(0.1f);
        }
    }
}
