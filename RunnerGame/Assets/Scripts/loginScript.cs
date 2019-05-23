using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using GoogleMobileAds.Api;

public class loginScript : MonoBehaviour
{
    private BannerView bannerView;
    // Start is called before the first frame update
    void Start()
    {
        // Recommended for debugging
       PlayGamesPlatform.DebugLogEnabled = true;

       // Activate the Google Play Games platform
       PlayGamesPlatform.Activate();

       //Call method Log In at the begging of the game
        LogIn();

     
    }

    // Update is called once per frame
    void Update()
    {
        
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
