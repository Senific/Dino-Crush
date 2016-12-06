using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnReplayClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void Resume()
    {
        Time.timeScale = 1;

        pausePanel.SetActive(false);
    }

    public void OpenLevelSelect()
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

    public void Show()
    {
        pausePanel.SetActive(true);
    }

}
