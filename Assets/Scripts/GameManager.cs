using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static bool isRestart;
    public void exitGame()
    {
        Application.Quit();
    }
    public void RestartGame()
    {
        isRestart = true;
        SceneManager.LoadScene(0);

    }
}
