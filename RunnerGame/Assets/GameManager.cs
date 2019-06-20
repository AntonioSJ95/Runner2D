using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GoogleMobileAds.Api;
using System;
using GoogleMobileAds;
public class GameManager : MonoBehaviour
{

    [SerializeField]
    private BackgroundElement[] BackgroundElement;
    private InterstitialAd interstitial;
    public Text currentScoreText;
     public int currentScore;
     public GameObject heart1, heart2, heart3, character,panel, coin, obstacle, pause, ResetGame;
     public static int health; 
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        SetScore();
        health = 3;
        RequestInterstitial();

        foreach(BackgroundElement element in BackgroundElement)
        {
            element.Move();
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {

          foreach(BackgroundElement element in BackgroundElement)
        {
            element.Move();
        }
        if(health > 3)
        health = 3;

        switch (health) 
        {
            case 3:
            heart1.gameObject.SetActive(true);
            heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(true);
            panel.gameObject.SetActive(false);
            break;
            case 2:
            heart1.gameObject.SetActive(false);
            heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(true);
            panel.gameObject.SetActive(false);
            break;
            case 1:
            heart1.gameObject.SetActive(false);
            heart2.gameObject.SetActive(false);
            heart3.gameObject.SetActive(true);
            panel.gameObject.SetActive(false);
            break;
            case 0:
            heart1.gameObject.SetActive(false);
            heart2.gameObject.SetActive(false);
            heart3.gameObject.SetActive(false);
            character.gameObject.SetActive(false);
            panel.gameObject.SetActive(true);
            coin.gameObject.SetActive(false);
            obstacle.gameObject.SetActive(false);
            pause.gameObject.SetActive(false);
            ResetGame.gameObject.SetActive(false);
            GameOver();
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

    public void RateUs()
    {
        #if UNITY_ANDROID
        Application.OpenURL("market://details?id=com.Frix.RunnerGame");

        #elif UNITY_IPHONE
        Application.OpenURL("details?id=com.Frix.RunnerGame&hl=es&ah=lYhqvWydJkzISby2rFkOiTQhbBs");

        #endif
    }


    //Publica el score
    public static void PostToLeaderboard(int currentScoreText)
    {
        Social.ReportScore(currentScoreText, GPGSIds.leaderboard_classic, (bool success) => {
            if(success)
            {
                Debug.Log("Si Classic");
            }
            else
            {
                Debug.LogError("No classic");
            }
        });     
    }


     private void RequestInterstitial()
     {
         #if UNITY_ANDROID
             string adUnitId = "ca-app-pub-8471546921544328/8961198402";
         #elif UNITY_IPHONE
             string adUnitId = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";
         #else
             string adUnitId = "unexpected_platform";
         #endif
                 
         // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
         // Load the interstitial with the request.
         this.interstitial.LoadAd(request); 
         
     }

     private void GameOver()
     {
         if(this.interstitial.IsLoaded())
         {
             this.interstitial.Show();
             Debug.Log("ad gameover");
         }
     }


}
