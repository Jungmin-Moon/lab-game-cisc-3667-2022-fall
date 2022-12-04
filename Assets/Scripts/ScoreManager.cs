using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreManager
{
    public static int playerScore = 0;

    
    public static void setScore(int s)
    {
        playerScore = s;
    }
    
    public static int getScore()
    {
        return playerScore;
    } 
}
