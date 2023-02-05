using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager i;

    private void Awake()
    {
        if (i == null)
        {
            i = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public List<RootData> deck;

    public static void LoadCredits()
    {
        SceneManager.LoadScene("Scenes/Credits");
    }
    
    public static void LoadMainMenu()
    {
        SceneManager.LoadScene("Scenes/Main Menu");
    }

    public static void Quit()
    {
        Application.Quit();
    }

    public static void LoadNextScene()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }
    
    public static void LoadVictory()
    {
        SceneManager.LoadScene("Scenes/Victory");
    }
    
    public static void LoadDefeat()
    {
        SceneManager.LoadScene("Scenes/Defeat");
    }
    
}
