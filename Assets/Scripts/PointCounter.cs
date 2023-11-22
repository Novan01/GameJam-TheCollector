using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script to keep track of score
public class PointCounter : MonoBehaviour
{
    public static PointCounter instance;

    public Text scoreText;

    public Text highScoreText;

    //score vairables
    int score = 0;
    int highScore = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //create our highscore and set + display score
        highScore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "Score: " + score.ToString();
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    //method to increase score
    public void AddPoint()
    {
        score += 1;
        scoreText.text = "Score: " + score.ToString();
        if (highScore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }

    }

    //method to return score
    public int Score()
    {
        return score;
    }
}
