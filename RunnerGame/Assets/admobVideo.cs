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
         // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        
         // Load an interstitial ad.
         this.interstitial.LoadAd(this.CreateAdRequest());
         
     }

     
     // Returns an ad request
     private AdRequest CreateAdRequest()
     {
         
         return new AdRequest.Builder().Build();
         
     }

     public void HandleOnAdClosed(object sender, EventArgs args)
     {
         interstitial.Destroy();
     }

     public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        interstitial.Destroy();
    }
     
     private void ShowInterstitial()
     { 
         if (interstitial.IsLoaded())
         {
             interstitial.Show();
         }
     }
     
     public void Start()
     {
         RequestInterstitial();
        
     }
     
     void Update()
     {
        ShowInterstitial();
         // Called when the ad click caused the user to leave the application.
        this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;
        this.interstitial.OnAdClosed += HandleOnAdClosed;
     }
 }

