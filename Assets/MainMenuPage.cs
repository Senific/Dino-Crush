﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MainMenuPage : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Play()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void ToggleMute(Button button)
    {
        AudioListener.pause = !AudioListener.pause;
    }

    public void OpenWebsite(string url)
    {
        Application.OpenURL(url);
    }
     
    public void Back()
    {
        SceneManager.LoadScene("Main");
    } 


    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif 
        Application.Quit();

    }
}
