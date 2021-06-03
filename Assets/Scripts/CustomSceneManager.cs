using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
    public static CustomSceneManager SceneManagerCustom;
    public bool test = false;
    private int levelsUnlocked = 0;
    public int GetLevelsUnlocked()
    {
        return levelsUnlocked;
    }
    private void Awake()
    {
        if (SceneManagerCustom != null)
        {
            Destroy(gameObject);
        }
        else
        {
            SceneManagerCustom = this;
            DontDestroyOnLoad(gameObject);
        }
        if(test)
        {
            Init();
        }

        if (!PlayerPrefs.HasKey("Unlocked"))
        {
            PlayerPrefs.SetInt("Unlocked", levelsUnlocked);
        }
        else
        {
            levelsUnlocked = PlayerPrefs.GetInt("Unlocked");
        }
    }
    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level != 0) //menu
        {
            Init();
        }
    } 
    public void Init()
    {
        EntityManager.InitEntities();
        TurnManager.NextTurn();
    }
    public void UnlockNextLevel()
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        if (buildIndex > levelsUnlocked)
        {
            levelsUnlocked = buildIndex; //1 level 1 2 level 2 and so on...
            PlayerPrefs.SetInt("Unlocked", levelsUnlocked);
            PlayerPrefs.Save();
        }
    }
}