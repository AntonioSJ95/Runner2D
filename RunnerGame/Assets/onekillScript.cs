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
public class onekillScript : MonoBehaviour
{

    [SerializeField]
    private BackgroundElement[] BackgroundElement;
    private InterstitialAd interstitial;
    public Text currentHardcoreText;
     public int scoreHardcore;
     public GameObject character,panel, coin, obstacle, pause, ResetGame,heartHardcore;
     public static int health; 
    // Start is called before the first frame update
    void Start()
    {
        scoreHardcore = 0;
        SetScore();
        health = 1;
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
        if(health > 1)
        health = 1;

        switch (health) 
        {
            case 1:
            heartHardcore.gameObject.SetActive(true);
            panel.gameObject.SetActive(false);
            break;
            case 0:
            heartHardcore.gameObject.SetActive(false);
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

    public void AddScoreHardcore()
    {
        scoreHardcore++;
        SetScore();
        PostToLeaderboard(scoreHardcore);
    }

    void SetScore()
    {
        currentHardcoreText.text = scoreHardcore.ToString();   
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
    public static void PostToLeaderboard(int currentHardcoreText)
    {
        Social.ReportScore(currentHardcoreText, GPGSIds.leaderboard_hardcore, (bool success) => {
            if(success)
            {
                Debug.Log("Si hardcore");
            }
            else
            {
                Debug.LogError("No hardcore");
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
