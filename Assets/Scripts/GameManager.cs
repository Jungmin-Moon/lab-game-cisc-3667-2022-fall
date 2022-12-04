using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    //public int playerScore = 0;
    public int highScore = 0;
    public Text scoreText;
    public Text highScoreText;

    
    private void Awake()
    {
        instance = this;
    } 
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = ScoreManager.playerScore + " Points";
        highScoreText.text = "Highscore: " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoint(int scoreValue)
    {
        int newScore = ScoreManager.playerScore + scoreValue;
        ScoreManager.setScore(newScore);
        scoreText.text = ScoreManager.getScore() + " Points";
    }
}
