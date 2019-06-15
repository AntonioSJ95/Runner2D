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

public class HealthBarScript : MonoBehaviour
{
     
    private InterstitialAd interstitial;

    public Text currentTimerText;
    private float startTime;

    Image healthBar;
    public static float maxHealth = 100;
    public static float health;

    public int currentTimer;
    public GameObject character,panel,healthBar1,ResetGame,obstacle,coin;
    // Start is called before the first frame update
    void Start()
    {
        currentTimer = 0;
        SetScore();
        healthBar = GetComponent<Image>();
        health = maxHealth;   
        RequestInterstitial();
        startTime = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;
        string seconds = (t % 999999).ToString("f0");
        currentTimerText.text = seconds;
        currentTimer = int.Parse(currentTimerText.text);
    
        

        healthBar.fillAmount = health / maxHealth;

        health -= 0.07f;

        

        if(health <= 0.00f)
        {
            character.gameObject.SetActive(false);
            character.gameObject.SetActive(false);
            panel.gameObject.SetActive(true);
            coin.gameObject.SetActive(false);
            obstacle.gameObject.SetActive(false);
            ResetGame.gameObject.SetActive(false);
            healthBar1.gameObject.SetActive(false);
           AddScore();
            GameOver();
        }

        
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

     public void AddScore()
    {
        //currentTimer++;
        SetScore();
        PostToLeaderboard(currentTimer);
    }

     void SetScore()
    {
        currentTimerText.text = currentTimer.ToString();  
    }
    

    public static void PostToLeaderboard(int currentTimerText)
    {
        Social.ReportScore(currentTimerText, GPGSIds.leaderboard_hardcore, (bool success) => {
            if(success)
            {
                Debug.Log("Si Hard");
            }
            else
            {
                Debug.LogError("No Hard");
            }
        });     
    }

     


    
}
