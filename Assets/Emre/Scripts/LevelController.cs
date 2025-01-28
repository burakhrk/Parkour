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
    GameObject cursor;


    bool gameEnd = false;
    
    //public List<GameObject> achievements;

    int a;
    

    [SerializeField] GameObject[] levels;
    [SerializeField] bool playSpecificLevel = false;
    public int Level;
    GameObject activeLevel;
    public TextMeshProUGUI Leveltext;
   public static bool isGamePlayStarted = false;
    private void Awake()
    {
        cursor=FindFirstObjectByType<Cursorr>().gameObject;
        if(!isGamePlayStarted)
        {
            isGamePlayStarted = true;
            Bridge.platform.SendMessage(Playgama.Modules.Platform.PlatformMessage.GameplayStarted); 
        }
        //a = Random.Range(0, achievements.Count);
        if (playSpecificLevel)
        {
            ActivateLevel();
            return;
        }


        if (PlayerPrefs.HasKey("Level"))
        {
            Level = PlayerPrefs.GetInt("Level", 1);
        }
        else
            Level = 1;

        ActivateLevel();
    }

    private void OnEnable()
    {
        Bridge.advertisement.interstitialStateChanged += OnInterstitialStateChanged;
        Bridge.advertisement.rewardedStateChanged += OnRewardedStateChanged;

    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }


    public int levelIndex;
    void ActivateLevel()
    {
        string a = " " + Level.ToString();
        string b = Leveltext.text;
        Leveltext.text = b + a;

        levelIndex = Level % (levels.Length + 1);


        if (Level <= levels.Length)
        {
            var go = Instantiate(levels[levelIndex - 1]);
            go.transform.position = levels[levelIndex - 1].transform.position;
            go.transform.parent = transform;
            go.SetActive(true);
            //  levels[levelIndex - 1].SetActive(true);
            activeLevel = go;


        }

        else
        {
            var go = Instantiate(levels[levelIndex]);
            go.transform.parent = transform;

            go.SetActive(true);
            activeLevel = go;

        }
    }
    public GameObject GetActiveLevel()
    {
        return activeLevel;
    } 
   
    private void OnInterstitialStateChanged(InterstitialState state)
    {
        if (state == InterstitialState.Opened)
        {
           
        }
        if (state == InterstitialState.Closed)
        {
            AfterAdNextLevel();
        }
        if (state == InterstitialState.Failed)
        {
            AfterAdNextLevel(); 
        }
        if (state == InterstitialState.Loading)
        {

        }

    }
    public void NextLevel()
    {
        Bridge.advertisement.ShowInterstitial(); 
    }
    void AfterAdNextLevel()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
       // Cursor.lockState = CursorLockMode.Locked;
        cursor.SetActive(true);
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
        //LosePanel.SetActive(false);
        //Cursor.lockState = CursorLockMode.Locked;
        cursor.SetActive(true);

    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }



    public void LosePanelActivate()
    {
        DeathSound.Play();
        LWLText.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        
        Time.timeScale = 0f;
        cursor.SetActive(false );
        LosePanel.SetActive(true);
        gameEnd = true;
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus&& gameEnd)
        {
        
            Cursor.lockState = CursorLockMode.None;

        }
    }
    public void ShowRewarded()
    {
        Bridge.advertisement.ShowRewarded();

    }
    private void OnRewardedStateChanged(RewardedState state)
    {
        if (state == RewardedState.Rewarded)
        {
            SetLewel();
        }
        if (state == RewardedState.Opened)
        {

        }
        if (state == RewardedState.Closed)
        {

        }
        if (state == RewardedState.Failed)
        {

        }
        if (state == RewardedState.Loading)
        {

        }

    }
    public void SetLewel()
    {
        PlayerPrefs.SetInt("Level", Level + 1);

        if(PlayerPrefs.GetInt("LevelUnlocked",1)<Level+1)
        {
            PlayerPrefs.SetInt("LevelUnlocked",Level+1);
        }
    }


    public void ActivateWinPanel()
    {
        SetLewel();

        gameEnd = true;

        LWLText.SetActive(false);
        WinSound.Play();
        cursor.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        

        Time.timeScale = 0f;
        //StartCoroutine(ActivateAchievements());
        cursor.SetActive(false);

        WinPanel.SetActive(true);   
    }

}