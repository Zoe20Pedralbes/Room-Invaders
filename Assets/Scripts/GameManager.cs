using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager gameManager;
    private GameObject player;

    [SerializeField]
    private GameObject loseGameOver, winGameOver;
    public InputField userField;
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

    public void Score() { _score++; }
    public void Score(int score) { _score = _score + score; }
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

    private void sendInformation()
    {
        StartCoroutine(cSendInformation());
    }
    IEnumerator cSendInformation()
    {
        WWWForm form = new WWWForm();
        form.AddField("playerName", userField.text);
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
