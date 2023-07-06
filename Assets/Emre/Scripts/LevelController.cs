using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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
    private void Awake()
    {
        cursor=FindObjectOfType<Cursorr>().gameObject;

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
    public void NextLevel()
    {
        
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
       // Cursor.lockState = CursorLockMode.Locked;
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

    IEnumerator ActivateAchievements() 
    { 

       // achievements[a].SetActive(true);
        yield return new WaitForSeconds(1f);
        //achievements[a].SetActive(false);

    }

    public void ActivateWinPanel()
    {
        PlayerPrefs.SetInt("Level", Level + 1);

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