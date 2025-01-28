using Playgama.Modules.Platform;
using UnityEngine; 
using Playgama;
using Unity;
using Playgama.Modules.Advertisement;
using System;
public class AdManager : MonoBehaviour
{ // Statik bir değişkenle kontrol sağlıyoruz
    public static bool hasRunInThisSession = false;

    void Start()
    {
        if (!hasRunInThisSession)
        {
            Bridge.platform.SendMessage(PlatformMessage.GameReady);
            Debug.Log("GameReady");
              hasRunInThisSession = true;
        }
        else
        {
         if(LevelController.isGamePlayStarted)
            {
                Debug.Log("Gameplaystopped");
                Bridge.platform.SendMessage(PlatformMessage.GameplayStopped);

            }
        }
        Bridge.advertisement.SetMinimumDelayBetweenInterstitial(60);
 
    }
   
    private void OnEnable()
    {
        Bridge.advertisement.interstitialStateChanged += OnInterstitialStateChanged;
        Bridge.advertisement.rewardedStateChanged += OnRewardedStateChanged;

    }

    private void OnRewardedStateChanged(RewardedState state)
    {
        if (state == RewardedState.Rewarded)
        {
            //reward
        }
        if (state == RewardedState.Opened)
        {
            AdOpenedState();
        }
        if (state == RewardedState.Closed)
        {
            AdFailedOrClosedState();
        }
        if (state == RewardedState.Failed)
        {
            AdFailedOrClosedState(); 
        }
        if (state == RewardedState.Loading)
        {

        }
     
    }
    void AdOpenedState()
    {
        AudioListener.volume = 0;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }
    void AdFailedOrClosedState()
    {
        AudioListener.volume = 1;
        Time.timeScale = 1f;

        // Cursor.lockState = CursorLockMode.Locked;
    }
    public void ShowIntersitial()
    {
        Bridge.advertisement.ShowInterstitial();

    }
    private void OnInterstitialStateChanged(InterstitialState state)
    {
       if(state==InterstitialState.Opened)
        {
            AdOpenedState();

        }
        if (state == InterstitialState.Closed)
        {
           AdFailedOrClosedState();

        }
        if (state == InterstitialState.Failed)
        {
            AdFailedOrClosedState();

        }
        if (state == InterstitialState.Loading)
        {

        }

    }
}
