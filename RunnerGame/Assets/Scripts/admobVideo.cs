using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using GoogleMobileAds;


public class admobVideo : MonoBehaviour
{
    private InterstitialAd interstitial;
     private void RequestInterstitial()
     {
         #if UNITY_ANDROID
             string adUnitId = "ca-app-pub-8471546921544328/2947161269";
         #elif UNITY_IPHONE
             string adUnitId = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";
         #else
             string adUnitId = "unexpected_platform";
         #endif  
         // Create an interstitial.
         this.interstitial = new InterstitialAd(adUnitId);
         // Load an interstitial ad.
         this.interstitial.LoadAd(this.CreateAdRequest());
     }

     
     // Returns an ad request
     private AdRequest CreateAdRequest()
     {
         return new AdRequest.Builder().Build();  
     }

 
     
     private void ShowInterstitial()
     { 
         if (interstitial.IsLoaded())
         {
             interstitial.Show();
         }
     }
     

     public void Awake()
     {
         Application.targetFrameRate = 60;
     }
     public void Start()
     {
         RequestInterstitial();
        
     }
     
     void Update()
     {
        ShowInterstitial();
     }
 }

