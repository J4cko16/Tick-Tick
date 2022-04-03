using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [Header("Score UI Settings")]
    public TextMeshProUGUI scoreDisplay;
    public TextMeshProUGUI highScoreDisplay;
    public bool inGame = true;
    public bool DisplayHiScore = true;

    float score;

    public void Start()
    {
        if (DisplayHiScore == true)
        {
            highScoreDisplay.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        }
    }

    public void Update()
    {
       if (inGame == true)
       {
            scoreDisplay.text = (int)score + "";
            score += 1f * Time.deltaTime;
       }
    }

    public void MoreScore()
    {
        score += 2;
    }

    public void LessScore()
    {
        if (score <= 5)
        {
            score = 0;
        }

        if (score >= 6)
        {
            score -= 6;
        }
    }

    public void HighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", (int)score);
            highScoreDisplay.text = score.ToString(); 
        }
    }

    public void ResetScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }
}

