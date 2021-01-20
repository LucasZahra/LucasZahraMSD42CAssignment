using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("CarGame");
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public static void LoadWinner()
    {
        SceneManager.LoadScene("Winner");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
