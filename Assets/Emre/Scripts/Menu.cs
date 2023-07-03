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
        _adManager.InterstatialAdManager.ShowAd();
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
