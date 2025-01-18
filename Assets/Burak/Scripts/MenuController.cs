using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    [SerializeField] AdManager _adManager;
    [SerializeField] GameObject page1, page2, page3;

    [SerializeField] List<LevelSelect> LevelSelectButtons;
    [SerializeField] List<Sprite> LevelSelectSprites;

    [SerializeField] int lastUnlockedLevel;
    [SerializeField] GameObject levelText;
    private void Awake()
    {
        InitButtons();
        FindLastUnlockedLevel();
        OpenPage1();
    }
    void FindLastUnlockedLevel()
    {
        if (PlayerPrefs.HasKey("LevelUnlocked"))
            lastUnlockedLevel = PlayerPrefs.GetInt("LevelUnlocked");
        else
            lastUnlockedLevel = 1;

        for (int i = 0; i < lastUnlockedLevel; i++)
        {
            LevelSelectButtons[i].Unlock();
        }
    }
    void InitButtons()
    {
        for (int i = 0; i < LevelSelectButtons.Count; i++)
        {
            LevelSelectButtons[i].Init(LevelSelectSprites[i],i+1,levelText);
        }
    }
   public void Play(int levelIndex)
    {
        // _adManager.InterstatialAdManager.ShowAd();
        SceneManager.LoadScene(1);
          PlayerPrefs.SetInt("Level", levelIndex);
        //Cursor.lockState = CursorLockMode.Locked;
    }


    public void OpenPage1()
    {
        page1.SetActive(true);
        page2.SetActive(false);
        page3.SetActive(false);

    }
    public void OpenPage2()
    {
        page1.SetActive(false);
        page2.SetActive(true);
        page3.SetActive(false);

    }
    public void OpenPage3()
    {
        page1.SetActive(false);
        page2.SetActive(false);
        page3.SetActive(true);


    }
}
