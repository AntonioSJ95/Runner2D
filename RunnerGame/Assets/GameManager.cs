using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
public class GameManager : MonoBehaviour
{
    public Text currentScoreText;
     public int currentScore;
     public GameObject heart1, heart2, heart3, character,leaderboard, play, coin, obstacle;
     public static int health; 
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        SetScore();
        health = 3;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
        leaderboard.gameObject.SetActive(false);
        play.gameObject.SetActive(false);
        coin.gameObject.SetActive(true);
        obstacle.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(health > 3)
        health = 3;

        switch (health) 
        {
            case 3:
            heart1.gameObject.SetActive(true);
            heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(true);
            leaderboard.gameObject.SetActive(false);
            play.gameObject.SetActive(false);
            break;
            case 2:
            heart1.gameObject.SetActive(false);
            heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(true);
            leaderboard.gameObject.SetActive(false);
            play.gameObject.SetActive(false);
            break;
            case 1:
            heart1.gameObject.SetActive(false);
            heart2.gameObject.SetActive(false);
            heart3.gameObject.SetActive(true);
            leaderboard.gameObject.SetActive(false);
            play.gameObject.SetActive(false);
            break;
            case 0:
            heart1.gameObject.SetActive(false);
            heart2.gameObject.SetActive(false);
            heart3.gameObject.SetActive(false);
            character.gameObject.SetActive(false);
            leaderboard.gameObject.SetActive(true);
            play.gameObject.SetActive(true);
            coin.gameObject.SetActive(false);
            obstacle.gameObject.SetActive(false);
            break;
        }
    }

    public void AddScore()
    {
        currentScore++;
        SetScore();
        PostToLeaderboard(currentScore);
    }

    void SetScore()
    {
        currentScoreText.text = currentScore.ToString();
        
    }


    //Publica el score
    public static void PostToLeaderboard(int currentScoreText)
    {
        Social.ReportScore(currentScoreText, GPGSIds.leaderboard_coins, (bool success) => {
            if(success)
            {
                Debug.Log("Se publico el score prro");
            }
            else
            {
                Debug.LogError("Nel perro no se publico");
            }
        });     
        }
}
