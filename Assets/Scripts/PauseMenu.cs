using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pausaUI;
    public GameObject HUD;
    public Button Continue;
    public Button Exit;



    // Start is called before the first frame update
    void Start()
    {
        Button btn = Continue.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    void TaskOnClick()
    {
        Resume();
    }

    public void Resume ()
    {
        pausaUI.SetActive(false);
        HUD.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = true;
    }

    public void Pause ()
    {
        pausaUI.SetActive(true);
        HUD.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = false;
    }

    public void Collectables()
    {
        SceneManager.LoadScene("Objectes");
    }

    public void Options()
    {
        SceneManager.LoadScene("Opcions");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}