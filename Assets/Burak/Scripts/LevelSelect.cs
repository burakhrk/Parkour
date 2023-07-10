using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelSelect : MonoBehaviour
{
    Button button;
    Image image;
     int levelIndex;
  
    public void Init(Sprite _sprite , int _index )
    {
        levelIndex = _index;

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

    }
    
}
