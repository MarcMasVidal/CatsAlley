using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
    public static CustomSceneManager SceneManagerCustom;
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
    private void Init()
    {

    }
}
