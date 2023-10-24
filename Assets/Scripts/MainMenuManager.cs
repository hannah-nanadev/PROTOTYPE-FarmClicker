using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private string gameScene = "Game";

    //Starts game
    public void StartGame()
    {
        SceneManager.LoadScene(gameScene);
    }

    //Exits game
    public void ExitGame()
    {
        Application.Quit();
    }

}
