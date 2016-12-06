using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject failScreen;

    public UnityEngine.UI.Text scoreText;
    public UnityEngine.UI.Text timeElapsedText;
    public UnityEngine.UI.Text movesText;
    public UnityEngine.UI.Button nextButton;

    public UnityEngine.UI.Image[] stars;


    private int levelID;

    // Use this for initialization
    void Start()
    {
        winScreen.SetActive(false);

        for (int i = 0; i < stars.Length; i++)
            stars[i].enabled = false;
    }


    public void ShowLose()
    {
        failScreen.SetActive(true);

        Animator animator = GetComponent<Animator>();

        if (animator)
        {
            animator.Play("GameOverShow");
        }
    }

    public void ShowWin(int score, int starCount, float timeElapsed, int moves, int levelID)
    {
        this.levelID = levelID;
        winScreen.SetActive(true);

        timeElapsedText.text = string.Format("{0}:{1:00}", timeElapsed / 60, timeElapsed % 60);
        scoreText.text = score.ToString();
        movesText.text = moves.ToString();

        nextButton.interactable = levelID < Level.NUMBER_OF_LEVELS;


        Animator animator = GetComponent<Animator>();

        if (animator)
        {
            animator.Play("GameOverShow");
        }

        StartCoroutine(ShowWinCoroutine(starCount));
    }

    private IEnumerator ShowWinCoroutine(int starCount)
    {
        yield return new WaitForSeconds(0.5f);


        if (starCount != 0)
        {
            for (int i = 0; i < starCount; i++)
            {
                stars[i].enabled = true;
                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    public void OnReplayClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void OnLevelSelectClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("levelSelect");
    }
    public void OnNext()
    {
        Debug.LogWarning("Not implemented!");
        return;

        UnityEngine.SceneManagement.SceneManager.LoadScene("Level" + (levelID + 1));
    }

    public void OpenWebsite(string url)
    {
        Application.OpenURL(url);
    }

}
