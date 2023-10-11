using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSetup : MonoBehaviour
{
    public void goMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void goSettings()
    {
        SceneManager.LoadScene(1);
    }

    public void startGame()
    {
        SceneManager.LoadScene(3);
    }
    public void stopGame()
    {
        Application.Quit();
    }
    public void goRanking()
    {
        SceneManager.LoadScene(2);
    }
}
