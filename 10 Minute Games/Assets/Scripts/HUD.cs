using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text scoreText;
    public Text highScore;

    public int score = 0;

    void Start()
    {
        highScore.text = "BEST: " + PlayerPrefs.GetInt("best");
    }

    public void StartGame()
    {
        InvokeRepeating("AddScore", 1f, 1f);        
    }

    void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
