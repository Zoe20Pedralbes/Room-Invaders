using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    private GameObject player;

    [SerializeField]
    private GameObject loseGameOver, winGameOver;
    public TextMeshProUGUI scoreText;
    [SerializeField]
    int _score = 0;

    public void setPlayer(GameObject player) { this.player = player; }
    public GameObject getPlayer() { return player; }

    private void Awake()
    {
        if (gameManager == null)
            gameManager = GetComponent<GameManager>();
        DontDestroyOnLoad(gameObject);
    }

    public void Score() { _score++; updateScore(); }
    public void Score(int score) { _score = _score + score; updateScore(); }
    public int GetScore() { return _score; }

    public void checkGame(int hp)
    {
        if (hp <= 0) GameOver();
    }

    private void GameOver()
    {
        winGameOver.SetActive(false);
        loseGameOver.SetActive(true);
    }

    public void winGame()
    {
        loseGameOver.SetActive(true);
        winGameOver.SetActive(false);
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
    }


    private void sendInformation()
    {
        StartCoroutine(cSendInformation());
    }
    IEnumerator cSendInformation()
    {
        WWWForm form = new WWWForm();
        form.AddField("playerName", scoreText.text);
        form.AddField("score", _score);
        //UnityWebRequest www = UnityWebRequest.Get("http://roominvaders.ddns.net/extract.php");
        UnityWebRequest www = UnityWebRequest.Post("http://roominvaders.ddns.net/insert.php", form);
        yield return www.Send();

        /*
        Jokes obj = new Jokes();

        string uwu = www.downloadHandler.text;
        Debug.Log(uwu);
        obj = JsonUtility.FromJson<Jokes>(uwu);

        Debug.Log(obj.value);
        _text.text = obj.value;
        */
    }

}
