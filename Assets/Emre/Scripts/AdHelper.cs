using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdHelper : MonoBehaviour
{

    public AdManager _adManager;


    private void Awake()
    {
        _adManager.Init();
    }

     void ShowAdd()
    {
        _adManager.InterstatialAdManager.ShowAd();
        Cursor.lockState = CursorLockMode.None;

    }


    public void ShowIntersAd()
    {
        if (_adManager.InterstatialAdManager.IsInterstatialAdReady())
        {
            _adManager.InterstatialAdManager.RegisterOnAdClosedEvent(OnAdClosed);
            ShowAdd();
        }
       
    }
    private void OnAdClosed(IronSourceAdInfo info)
    {
        _adManager.InterstatialAdManager.UnRegisterOnAdClosedEvent(OnAdClosed);
        Cursor.lockState = CursorLockMode.Locked;

        Debug.Log("OnAdClosed");
    }
   

}
