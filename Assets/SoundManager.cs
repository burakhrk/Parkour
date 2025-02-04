using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    public bool isMuted; // Kullanıcının sesi kapatıp kapatmadığını takip eder
    private bool wasMutedBeforeAd; // Reklam öncesi ses durumu
    public Sprite SoundOnButton,SoundOffButton;
    private const string MutePrefKey = "MuteSetting";
    public SoundToggleButton toggleButton;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadMuteSetting();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void LoadMuteSetting()
    {
        isMuted = PlayerPrefs.GetInt(MutePrefKey, 0) == 1;
        ApplyMuteSetting();
    }

    private void ApplyMuteSetting()
    {
        AudioListener.volume = isMuted ? 0f : 1f;
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        PlayerPrefs.SetInt(MutePrefKey, isMuted ? 1 : 0);
        PlayerPrefs.Save();
        ApplyMuteSetting();
    }

    public void MuteForAd()
    {
        wasMutedBeforeAd = isMuted;
        AudioListener.volume = 0f; // Reklam sırasında sesi tamamen kapat
        Time.timeScale = 0f;
 
    }

    public void UnmuteAfterAd()
    {
        isMuted = wasMutedBeforeAd;
        ApplyMuteSetting(); // Reklam bitince eski kullanıcı tercihini uygula
        Time.timeScale = 1f;
 
    }
}
