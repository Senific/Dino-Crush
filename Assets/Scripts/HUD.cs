using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    public Level level;
    public GameOver gameOver;

    public UnityEngine.UI.Text remainingText;
    public UnityEngine.UI.Text remainingSubtext;
    public UnityEngine.UI.Text targetText;
    public UnityEngine.UI.Text targetSubtext;
    public UnityEngine.UI.Text scoreText;
    public UnityEngine.UI.Image[] stars;

    public UnityEngine.UI.Text movesRemainingText;
    public UnityEngine.UI.Text timeRemainingText;
    public UnityEngine.UI.Text obstacleRemainingText;
    public UnityEngine.UI.Text leveText;

    public GameObject timePanel;
    public GameObject obstaclesPanel;
    public GameObject movesPanel;

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
        for (int i = 0; i < stars.Length; i++)
        {
            if (i == starIdx)
            {
                stars[i].enabled = true;
            }
            else
            {
                stars[i].enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetScore(int score)
    {
        this.score = score;
        scoreText.text = score.ToString();


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

        for (int i = 0; i < stars.Length; i++)
        {
            if (i == visibleStar)
            {
                stars[i].enabled = true;
            }
            else
            {
                stars[i].enabled = false;
            }
        }

        starIdx = visibleStar;
    }




    public void SetMovesRemaining(int remaining)
    {
        this.movesRemaining = remaining;
        movesRemainingText.text = remaining.ToString();
    }
    public void SetObstacleRemaining(int remaining)
    {
        this.obstacleRemaining = remaining;
        obstacleRemainingText.text = remaining.ToString();
    }
    public void SetTimeRemaining(int remaining)
    {
        this.timeTemaining = remaining;
        timeRemainingText.text = string.Format("{0}:{1:00}", remaining / 60, remaining % 60);
    }

    public void SetLevelID(int id)
    {
        levelID = id;
        leveText.text = string.Format("{0}/{1}", id, Level.NUMBER_OF_LEVELS);
    }


    public void SetLevelType(Level.LevelType type)
    {
        levelType = type;


        timePanel.SetActive(false);
        movesPanel.SetActive(false);
        obstaclesPanel.SetActive(false);

        if (levelType == Level.LevelType.MOVES)
        {
            movesPanel.SetActive(true);
        }
        else if (levelType == Level.LevelType.OBSTACLE)
        {
            movesPanel.SetActive(true);
            obstaclesPanel.SetActive(true);
        }


        //if (type == Level.LevelType.MOVES)
        //{
        //    remainingSubtext.text = "moves remaining";
        //    targetSubtext.text = "target score";
        //}
        //else if (type == Level.LevelType.OBSTACLE)
        //{
        //    remainingSubtext.text = "moves remaining";
        //    targetSubtext.text = "bubbles remaining";
        //}
        //else if (type == Level.LevelType.TIMER)
        //{
        //    remainingSubtext.text = "time remaining";
        //    targetSubtext.text = "target score";
        //}
    }

    public void OnGameWin(int score, float timeElapsed, int totalMoves)
    {
        gameOver.ShowWin(score, starIdx, timeElapsed, totalMoves);
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

    }
}
