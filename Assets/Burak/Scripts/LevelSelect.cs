using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using Playgama;
using Playgama.Modules.Advertisement;
public class LevelSelect : MonoBehaviour
{
    Button button;
   [SerializeField] Image image;
    [SerializeField] Image bgimage;

    [SerializeField]    int levelIndex;
  
    public void Init(Sprite _sprite , int _index,GameObject levelText )
    {
            levelIndex = _index;

        GameObject go = Instantiate(levelText, transform);
        go.GetComponent<TextMeshProUGUI>().text = "Level " + levelIndex.ToString();

         
        image.sprite = _sprite;

        button = GetComponent<Button>();
        button.onClick.AddListener(LevelSelected);

        Lock();
    }
    private void OnInterstitialStateChanged(InterstitialState state)
    {
        if (state == InterstitialState.Opened)
        {

        }
        if (state == InterstitialState.Closed)
        {
            LoadSelectedLevel();
            Cursor.lockState = CursorLockMode.None;
        }
        if (state == InterstitialState.Failed)
        {
            LoadSelectedLevel();
            Cursor.lockState = CursorLockMode.None;

        }
        if (state == InterstitialState.Loading)
        {

        }
        Debug.Log("Intersitial State");

    }
    void Lock()
    {
        button.interactable = false;
        image.color = Color.grey;
    }
    public void Unlock()
    {
        button.interactable = true;
        image.color = Color.white;
    }
    void LoadSelectedLevel()
    {
        FindFirstObjectByType<MenuController>().Play(levelIndex);

    }
    public void LevelSelected()
    {
        Bridge.advertisement.ShowInterstitial(); 
    }
    
}
