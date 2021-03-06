using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    int score = 0;
    TMP_Text scoreText;

    void Start() 
    {
        scoreText = GetComponent<TMP_Text>();
        UpdateScoreBoard(score.ToString());    
    }

    public void IncreaseScore(int amountToIncrease)
    {
        score += amountToIncrease;
        UpdateScoreBoard(score.ToString());
    }

    private void UpdateScoreBoard(string newScore)
    {
        scoreText.text = newScore;
    }
}
