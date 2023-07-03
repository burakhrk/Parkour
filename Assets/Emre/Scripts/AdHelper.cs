using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdHelper : MonoBehaviour
{

    public AdManager _adManager;


    private void Awake()
    {
        _adManager.Init();
    }

    public void ShowIntAd()
    {
        _adManager.InterstatialAdManager.ShowAd();
    }
}
