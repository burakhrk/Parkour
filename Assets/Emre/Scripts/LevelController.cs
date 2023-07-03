using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelController : MonoBehaviour
{

    public GameObject LWLText;

    public GameObject Player;
    public GameObject LosePanel;
    public GameObject WinPanel;
    GameObject cursor;

    
    public List<GameObject> achievements;

    int a;
    

    [SerializeField] GameObject[] levels;
    [SerializeField] bool playSpecificLevel = false;
    public int Level;
    GameObject activeLevel;
    public TextMeshProUGUI Leveltext;
    private void Awake()
    {
        cursor=FindObjectOfType<Cursorr>().gameObject;

        a = Random.Range(0, achievements.Count);
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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)) 
        {
            NextLevel();
        }
        

        
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
    public void NextLevel()
    {
        
        PlayerPrefs.SetInt("Level", Level + 1);
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        //Cursor.lockState = CursorLockMode.Locked;
        cursor.SetActive(true);

    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        LosePanel.SetActive(false);
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
        Time.timeScale = 0f;
        LWLText.SetActive(false);
        //Cursor.lockState = CursorLockMode.None;
        cursor.SetActive(false );
        LosePanel.SetActive(true);
    }
    
    IEnumerator ActivateAchievements() 
    { 

        achievements[a].SetActive(true);
        yield return new WaitForSeconds(1f);
        achievements[a].SetActive(false);

    }

    public void ActivateWinPanel()
    {
        LWLText.SetActive(false);

        cursor.SetActive(false);
       // Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        StartCoroutine(ActivateAchievements());
        cursor.SetActive(false);

        WinPanel.SetActive(true);   
    }

}