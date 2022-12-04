using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Game_Back_To_Main : MonoBehaviour
{
    public void BackToStartMenu()
    {
        SceneManager.LoadScene(0);
    }
}
