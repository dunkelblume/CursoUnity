using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    public Text ScoreText;
    public Image ScoreIcon;
    int score = 0;
    int highScore = 0;

    public void Start()
    {
        GetLastHighScore();
    }

    public void UpdateScore()
    {
        score++;
        ScoreText.text = score.ToString();
        SetColorIcon();

        if (score > highScore)
            SaveScore(score);
    }

    public void SetColorIcon()
    {
        ScoreIcon.color = Color.white;
    }

    public void WrongAnswer()
    {
        ScoreIcon.color = Color.red;
    }

    public void WrongAnswer(ColorProperties[] availableColors)
    {
        for(int i = 0; i<availableColors.Length; i++)
        {
            if(availableColors[i].Name == "Red")
            {
                ScoreIcon.color = availableColors[i].color;
            }
        }
    }

    public void WrongAnswer(ColorProperties[] availableColors,string _wrongColor)
    {
        for (int i = 0; i < availableColors.Length; i++)
        {
            if (availableColors[i].Name == _wrongColor)
            {
                ScoreIcon.color = availableColors[i].color;
            }
        }
    }


    public void GetLastHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
    }

    public void SaveScore(int _score)
    {
        ScoreIcon.color = Color.green;
        PlayerPrefs.SetInt("HighScore", _score);
    }
}
