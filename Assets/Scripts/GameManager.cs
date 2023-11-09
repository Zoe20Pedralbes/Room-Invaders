using FMODUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager = null;
    [SerializeField] private GameObject player;
    [SerializeField] private int playerLife = 5;
    [SerializeField] private GameObject loseGameOver, winGameOver;
    public TextMeshProUGUI scoreText;
    [SerializeField] private Text userNameText;
    [SerializeField] private List<Animator> HealthUiAnimations;
    [SerializeField]
    int _score = 0;
    [SerializeField] Camera staticCamera;
    public Camera getStaticCamera()
    {
        return staticCamera;
    }

    public void setPlayer(GameObject player) { this.player = player; }
    public GameObject getPlayer() { return player; }

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
            Debug.Log(gameManager + "  gamemanager");
        }
        else
            Destroy(this.gameObject);
        if (player != null)
        {
            player.GetComponent<playerHealth>().maxHealth = playerLife;
        }
        Time.timeScale = 1f;
        recargarParametros();
    }
    public int getMaxLife()
    {
        return playerLife;
    }


    public void Score() { _score++; updateScore(); }
    public void Score(int score) { _score = _score + score; updateScore(); }
    public int GetScore() { return _score; }

    public void checkGame(int hp)
    {
        switch (hp)
        {
            case 2:
                HealthUiAnimations[2].SetInteger("LifePoints", hp);
                break;
            case 1:
                HealthUiAnimations[1].SetInteger("LifePoints", hp); break;
            case 0:
                HealthUiAnimations[0].SetInteger("LifePoints", hp); GameOver(); break;
        }
    }

    private void GameOver()
    {
        
        Debug.Log("GameOver");
        loseGameOver.SetActive(true);
        winGameOver.SetActive(false);
        Time.timeScale = 0f;
        audioManager.AudioManager.PlayOneShot(FMODEvents.instance.gameOverSound, player.transform.position);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // winGameOver.SetActive(false);
        // loseGameOver.SetActive(true);
    }
    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    void recargarParametros()
    {
        loseGameOver = GameObject.FindGameObjectsWithTag("GameOver")[0];
        winGameOver = GameObject.FindGameObjectsWithTag("HighScore")[0];
        scoreText = GameObject.FindGameObjectsWithTag("ScoreText")[0].GetComponent<TextMeshProUGUI>();
        userNameText = GameObject.FindGameObjectsWithTag("userNameText")[0].GetComponent<Text>();
        foreach (var corazon in GameObject.FindGameObjectsWithTag("Corazon"))
        {
            HealthUiAnimations.Add(corazon.GetComponent<Animator>());
        }
        staticCamera = Camera.allCameras[1];
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void winGame()
    {
        Time.timeScale = 0;
        loseGameOver.SetActive(false);
        winGameOver.SetActive(true);
    }

    void checkRanking()
    {
        GetInformation();
    }

    void updateScore()
    {
        scoreText.text = "Score: " + _score;
    }

    private void OnValidate()
    {
        updateScore();
    }

    private void OnEnable()
    {
        enemyHealth.OnEnemyDie += Score;
        //SceneManager.sceneLoaded += OnSceneLoaded;        
    }

    private void GetInformation()
    {
        StartCoroutine(cGetInformation());
    }
    IEnumerator cGetInformation()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://roominvaders.ddns.net/extract.php");
        yield return www.SendWebRequest();

        string sRanking = www.downloadHandler.text;
        Player[] player = JsonHelper.FromJson<Player>(sRanking);
        foreach (Player p in player)
        {
            Debug.Log("User: " + p.name + " score: " + p.score);
        }
    }
    public void sendInformation()
    {
        StartCoroutine(cSendInformation());
        SceneManager.LoadScene(2);
    }
    IEnumerator cSendInformation()
    {
        WWWForm form = new WWWForm();
        form.AddField("playerName", userNameText.text);
        form.AddField("score", _score);
        UnityWebRequest www = UnityWebRequest.Post("http://roominvaders.ddns.net/insert.php", form);
        yield return www.SendWebRequest();
    }

    private class Player
    {
        public string name;
        public int score;
    }

    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.HighScores;
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] HighScores;
        }
    }

}
