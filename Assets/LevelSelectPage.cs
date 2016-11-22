using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectPage : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Back()
    {
        SceneManager.LoadScene("Main");
    }

    public void OpenLevel(int levelNumber)
    {
        SceneManager.LoadScene("Level" + levelNumber);
    }

    public void ToggleMute(Button button)
    {
        AudioListener.pause = !AudioListener.pause;
    }

    public void OpenWebsite(string url)
    {
        Application.OpenURL(url);
    }
}
