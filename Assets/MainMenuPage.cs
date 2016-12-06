using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if  UNITY_EDITOR
using UnityEditor;
#endif
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
        SceneManager.LoadScene("Level1");
    }

    public void ToggleMute(Button button)
    {
        AudioListener.pause = !AudioListener.pause;
    }

    public void OpenWebsite(string url)
    {
        Application.OpenURL(url);
    }




    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif 
        Application.Quit();

    }
}
