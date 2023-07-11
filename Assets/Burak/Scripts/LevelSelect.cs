using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelSelect : MonoBehaviour
{
    Button button;
    Image image;
 [SerializeField]    int levelIndex;
  
    public void Init(Sprite _sprite , int _index,GameObject levelText )
    {
            levelIndex = _index;

        GameObject go = Instantiate(levelText, transform);
        go.GetComponent<TextMeshProUGUI>().text = "Level " + levelIndex.ToString();

        image = GetComponent<Image>();
        image.sprite = _sprite;

        button = GetComponent<Button>();
        button.onClick.AddListener(LevelSelected);

        Lock();
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

    public void LevelSelected()
    {
        FindObjectOfType<MenuController>().Play(levelIndex);
    }
    
}
