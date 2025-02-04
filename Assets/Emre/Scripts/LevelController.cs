using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Playgama;
using Playgama.Modules.Advertisement;

public class LevelController : MonoBehaviour
{
    public AudioSource DeathSound;
    public AudioSource WinSound;
    public GameObject LWLText;
    public GameObject Player;
    public GameObject LosePanel;
    public GameObject WinPanel;
    public GameObject pausePanel;
    [SerializeField] SoundToggleButton toggleButton;
    GameObject cursor;

    bool gameEnd = false;
    int levelIndex = 0; // levelIndex tanımlandı
    int Level = 1; // Varsayılan seviye
    GameObject activeLevel;
    public TextMeshProUGUI Leveltext;
    public static bool isGamePlayStarted = false;

    [SerializeField] GameObject[] levels;
    [SerializeField] bool playSpecificLevel = false;

    private void Awake()
    {
        cursor = FindFirstObjectByType<Cursorr>().gameObject;
        if (!isGamePlayStarted)
        {
            isGamePlayStarted = true;
            Bridge.platform.SendMessage(Playgama.Modules.Platform.PlatformMessage.GameplayStarted);
        }
    }

    private void Start()
    {
        toggleButton.DisappearButton();
        Cursor.lockState = CursorLockMode.Locked;

        if (playSpecificLevel)
        {
            ActivateLevel();
            return;
        }

        // 'Level' verisini yükle
        Bridge.storage.Get("Level", OnStorageGetCompleted);
    }

    private void OnStorageGetCompleted(bool success, string data)
    {
        if (success && !string.IsNullOrEmpty(data))
        {
            Level = int.Parse(data);
        }
        else
        {
            Level = 1; // Varsayılan değer
        }

        ActivateLevel();
    }

 

    void ActivateLevel()
    {
        Leveltext.text = "Level " + Level.ToString();

        levelIndex = (Level - 1) % levels.Length; // Hata düzeltildi

        var go = Instantiate(levels[levelIndex]);
        go.transform.parent = transform;
        go.SetActive(true);
        activeLevel = go;
    }

    public GameObject GetActiveLevel()
    {
        return activeLevel;
    }

    private void OnInterstitialStateChanged(InterstitialState state)
    {
        if (state == InterstitialState.Opened)
        {
            SoundManager.Instance.MuteForAd();
        }
        if (state == InterstitialState.Closed || state == InterstitialState.Failed)
        {
            AfterAdNextLevel();
            SoundManager.Instance.UnmuteAfterAd();
        }
        Bridge.advertisement.interstitialStateChanged -= OnInterstitialStateChanged;

    }

    public void NextLevel()
    {

        Bridge.advertisement.interstitialStateChanged += OnInterstitialStateChanged;
        Bridge.advertisement.ShowInterstitial();
    }

    void AfterAdNextLevel()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        cursor.SetActive(true);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        { ActivatePausePanel();
        }
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
        cursor.SetActive(true);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
   public void ActivatePausePanel()
    {
        pausePanel.SetActive(true);
        cursor.SetActive(false);
        Cursor.lockState = CursorLockMode.None;

        Time.timeScale = 0f;
        toggleButton.VisibleButton();

    }
    public void DisablePausePanel()
    {
        pausePanel.SetActive(false);
        cursor.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;

        Time.timeScale = 1f;
        toggleButton.DisappearButton();

    }
    public void LosePanelActivate()
    {
        DeathSound.Play();
        LWLText.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        cursor.SetActive(false);
        LosePanel.SetActive(true);
        gameEnd = true;
        toggleButton.VisibleButton();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus && gameEnd)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void ShowRewarded()
    {
        Bridge.advertisement.rewardedStateChanged += OnRewardedStateChanged;
        Bridge.advertisement.ShowRewarded();
    }

    private void OnRewardedStateChanged(RewardedState state)
    {
        if (state == RewardedState.Rewarded)
        {
            SetLevel();
            Debug.Log("reward");
            SoundManager.Instance.UnmuteAfterAd();
        }
        if (state == RewardedState.Opened)
        {
            SoundManager.Instance.MuteForAd();
        }
        if (state == RewardedState.Closed || state == RewardedState.Failed)
        {
            Cursor.lockState = CursorLockMode.None;
            cursor.SetActive(false);
            SoundManager.Instance.UnmuteAfterAd();
            Debug.Log("reward failed or closed");

        } 
        Bridge.advertisement.rewardedStateChanged -= OnRewardedStateChanged; 
    }

    public void SetLevel()
    {
        Level += 1;

        // 'Level' verisini kaydet
        Bridge.storage.Set("Level", Level.ToString(), OnStorageSetCompleted);

        // Kilidi açılan en yüksek seviyeyi güncelle
        Bridge.storage.Get("LevelUnlocked", OnLevelUnlockedGetCompleted);
    }

    private void OnStorageSetCompleted(bool success)
    {
        if (!success)
        {
            Debug.LogError("Veri kaydedilirken hata oluştu.");
        }
    }

    private void OnLevelUnlockedGetCompleted(bool success, string data)
    {
        if (success && !string.IsNullOrEmpty(data))
        {
            int levelUnlocked = int.Parse(data);
            if (levelUnlocked < Level)
            {
                Bridge.storage.Set("LevelUnlocked", Level.ToString(), OnStorageSetCompleted);
            }
        }
        else
        {
            Bridge.storage.Set("LevelUnlocked", Level.ToString(), OnStorageSetCompleted);
        }
    }

    public void ActivateWinPanel()
    {
        SetLevel();

        gameEnd = true;

        LWLText.SetActive(false);
        WinSound.Play();
        cursor.SetActive(false);
        Cursor.lockState = CursorLockMode.None;

        Time.timeScale = 0f;

        WinPanel.SetActive(true);
        toggleButton.VisibleButton();
    }
}
