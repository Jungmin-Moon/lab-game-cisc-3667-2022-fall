using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Game_Button : MonoBehaviour
{

    //public int gameStartScene; 

    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    } */

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToInstructions()
    {
        SceneManager.LoadScene(4);
    }
}
