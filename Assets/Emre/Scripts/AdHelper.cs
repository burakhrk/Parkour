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
            

            _adManager.InterstatialAdManager.RegisterOnAdClosedEvent(OnAdClosed);
            ShowAdd();
        }
        else
        {
           // Cursor.lockState = CursorLockMode.Locked;

        }

    }
    private void OnAdClosed(IronSourceAdInfo info)
    {
        _adManager.InterstatialAdManager.UnRegisterOnAdClosedEvent(OnAdClosed);
        //Cursor.lockState = CursorLockMode.Locked;

        Debug.Log("OnAdClosed");
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

        _adManager.RewardedAdManager.UnRegisterOnUserEarnedRewarededEvent(OnUserEarnedReward);
        _adManager.RewardedAdManager.UnRegisterOnAdClosedEvent(OnRewardedAdClosed);

        if (_isRewardEarned)
        {
            _levelController.NextLevel();
        }

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
