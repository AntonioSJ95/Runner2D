﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using GoogleMobileAds.Api;

public class loginScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        // Recommended for debugging
       PlayGamesPlatform.DebugLogEnabled = false;
       // Activate the Google Play Games platform
       PlayGamesPlatform.Activate();
       //Call method Log In at the begging of the game
        LogIn();
    }


    public void Awake()
     {
         Application.targetFrameRate = 60;
     }


     public void LogIn()
   {
       Social.localUser.Authenticate((bool success) =>
       {
           if (success)
           {
               Debug.Log("Login Sucess");
           }
           else
           {
               Debug.Log("Login failed");
           }
       });
   }
}
