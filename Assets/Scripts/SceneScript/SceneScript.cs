using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    public static SceneScript Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void LoadAchievementsWSound()
    {
        SceneManager.LoadScene("Achievements");
    }
    
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void loadLog()
    {
        SceneManager.LoadScene("Log");
    }
}
