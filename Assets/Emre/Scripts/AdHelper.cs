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
   

}
