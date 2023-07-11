using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdHelper : MonoBehaviour
{

    public AdManager _adManager;
    public LevelController _levelController;

    private void Awake()
    {
        _adManager.Init();
    }

    private void Start()
    {
       // ShowIntersAd();
    }


    void ShowAdd()
    {
        _adManager.InterstatialAdManager.ShowAd();
        

    }


    public void ShowIntersAd()
    {
        if (_adManager.InterstatialAdManager.IsInterstatialAdReady())
        {
            _adManager.InterstatialAdManager.RegisterOnAdShowFailedEvent(OnAdClosed3);
            _adManager.InterstatialAdManager.RegisterOnAdLoadFailedEvent(OnAdClosed2);
            _adManager.InterstatialAdManager.RegisterOnAdClosedEvent(OnAdClosed);
            ShowAdd();
        }
        else
        {
            Time.timeScale = 1f;
            _levelController.NextLevel();
        }

    }

    private void OnAdClosed2(IronSourceError error)
    {
        _adManager.InterstatialAdManager.UnRegisterOnAdShowFailedEvent(OnAdClosed3);
        _adManager.InterstatialAdManager.UnRegisterOnAdLoadFailedEvent(OnAdClosed2);
        _adManager.InterstatialAdManager.UnRegisterOnAdClosedEvent(OnAdClosed);
        Time.timeScale = 1f;
    }
    private void OnAdClosed3(IronSourceError error, IronSourceAdInfo info)
    {
        _adManager.InterstatialAdManager.UnRegisterOnAdShowFailedEvent(OnAdClosed3);
        _adManager.InterstatialAdManager.UnRegisterOnAdLoadFailedEvent(OnAdClosed2);
        _adManager.InterstatialAdManager.UnRegisterOnAdClosedEvent(OnAdClosed);
        Time.timeScale = 1f;

    }


    private void OnAdClosed(IronSourceAdInfo info)
    {
        _adManager.InterstatialAdManager.UnRegisterOnAdShowFailedEvent(OnAdClosed3);
        _adManager.InterstatialAdManager.UnRegisterOnAdLoadFailedEvent(OnAdClosed2);
        _adManager.InterstatialAdManager.UnRegisterOnAdClosedEvent(OnAdClosed);
        Time.timeScale = 1f;

    }

    bool _isRewardEarned=false;

    public void ShowRewardAd()
    {


        if (_adManager.RewardedAdManager.IsRewardedAdReady())
        {
            _adManager.RewardedAdManager.RegisterOnUserEarnedRewarededEvent(OnUserEarnedReward);
            _adManager.RewardedAdManager.RegisterOnAdClosedEvent(OnRewardedAdClosed);

            ShowRewardedAd();
        }
       
       
    }
    private void OnRewardedAdClosed(IronSourceAdInfo info)
    {
        _levelController.SetLewel();

        _adManager.RewardedAdManager.UnRegisterOnUserEarnedRewarededEvent(OnUserEarnedReward);
        _adManager.RewardedAdManager.UnRegisterOnAdClosedEvent(OnRewardedAdClosed);

        _levelController.NextLevel();

        _isRewardEarned = false;
        


    }
    private void OnUserEarnedReward(IronSourcePlacement placement, IronSourceAdInfo info)
    {

        _isRewardEarned = true;
        
    }

    private void ShowRewardedAd()
    {

        _adManager.RewardedAdManager.ShowAd();
    }

}
