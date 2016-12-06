using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    public Level level;
    public GameOver gameOver;
    public PauseMenu pauseMenu;

    public Text TimeRemainingText;
    public Text ScoreText;
    public Image[] Stars;

    private int score;
    private int obstacleRemaining;
    private int timeTemaining;
    private int movesRemaining;

    private int starIdx = 0;

    private int levelID = 0;

    private Level.LevelType levelType;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetScore(int score)
    {
        this.score = score;
        ScoreText.text = score.ToString();


        int visibleStar = 0;

        if (score >= level.score1Star && score < level.score2Star)
        {
            visibleStar = 1;
        }
        else if (score >= level.score2Star && score < level.score3Star)
        {
            visibleStar = 2;
        }
        else if (score >= level.score3Star)
        {
            visibleStar = 3;
        }


        for (int i = 0; i < visibleStar; i++)
        {
            Debug.Log(i);
            Stars[i].enabled = true;
        }

        starIdx = visibleStar;
    }




    public void SetTimeRemaining(int remaining)
    {
        this.timeTemaining = remaining;
        TimeRemainingText.text = string.Format("{0}:{1:00}", remaining / 60, remaining % 60);
    }

    public void SetLevelID(int id)
    {
        levelID = id;
    }


    public void SetLevelType(Level.LevelType type)
    {
        levelType = type;
    }

    public void OnGameWin(int score, float timeElapsed, int totalMoves)
    {
        gameOver.ShowWin(score, starIdx, timeElapsed, totalMoves, levelID);
        if (starIdx > PlayerPrefs.GetInt(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name, 0))
        {
            PlayerPrefs.SetInt(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name, starIdx);
        }
    }

    public void OnGameLose()
    {
        gameOver.ShowLose();
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

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.Show();
    }
}
