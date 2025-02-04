using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Playgama;
using Playgama.Modules.Advertisement;
public class Menu : MonoBehaviour
{
    public GameObject LWLSelectPanel;

    [SerializeField] AdManager _adManager;
     
    private void OnEnable()
    {
        Bridge.advertisement.interstitialStateChanged += OnInterstitialStateChanged;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None; 
    } 
    void AdClosed()
    {
         Cursor.lockState = CursorLockMode.None;
         if (PlayerPrefs.HasKey("LevelUnlocked"))
        {
            var a = PlayerPrefs.GetInt("LevelUnlocked", 1);
            PlayerPrefs.SetInt("Level", a); 
        }
        else
        { 
            PlayerPrefs.SetInt("Level", 1);
        }
         
        SceneManager.LoadScene(1);
    }
    private void OnInterstitialStateChanged(InterstitialState state)
    {
        if (state == InterstitialState.Opened)
        {
             AdOpenedState();
            SoundManager.Instance.MuteForAd();
        }
        if (state == InterstitialState.Closed)
        {
           AdClosed();
            SoundManager.Instance.UnmuteAfterAd();
            Cursor.lockState = CursorLockMode.None;
         }
        if (state == InterstitialState.Failed)
        {
            AdClosed();
            Cursor.lockState = CursorLockMode.None;
            SoundManager.Instance.UnmuteAfterAd();

            Debug.Log("Failed ad play Button");

        }
        if (state == InterstitialState.Loading)
        {

        }
        Debug.Log("Intersitial State");

    }
    void AdOpenedState()
    {
         Cursor.lockState = CursorLockMode.None;
     }
    public void PlayButton()
    {
        Bridge.advertisement.ShowInterstitial();
        Debug.Log("Play Button");
    }

    public void ShowAd()
    {
       // _adManager.InterstatialAdManager.ShowAd();
    }



    public void ActivateLWLSelecetPanel()
    {
        LWLSelectPanel.SetActive(true);
    }

    public void CloseLWLSelecetPanel()
    {
        LWLSelectPanel.SetActive(false);
    }
}
