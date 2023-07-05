using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] AdManager _adManager;

    private void Awake()
    {
        _adManager.Init();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;

        ShowAd();
    }

    public void PlayButton()
    {
        ShowAd();
        SceneManager.LoadScene(1);
        //Cursor.lockState = CursorLockMode.Locked;
    }

    public void ShowAd()
    {
        _adManager.InterstatialAdManager.ShowAd();
    }

}
