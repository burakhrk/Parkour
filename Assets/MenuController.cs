using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject page1, page2, page3;

    [SerializeField] List<LevelSelect> LevelSelectButtons;
    [SerializeField] List<Sprite> LevelSelectSprites;

    private void Awake()
    {
        InitButtons();
        OpenPage1();
    }
    void InitButtons()
    {
        for (int i = 0; i < LevelSelectButtons.Count; i++)
        {
            LevelSelectButtons[i].Init(LevelSelectSprites[i],i+1);
        }
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
