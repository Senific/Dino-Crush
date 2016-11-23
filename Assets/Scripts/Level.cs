using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour
{
    public const int NUMBER_OF_LEVELS = 18;


    public enum LevelType
    {
        TIMER,
        OBSTACLE,
        MOVES,
    };

    public int levelID;

    public Grid grid;
    public HUD hud;

    public int score1Star;
    public int score2Star;
    public int score3Star;

    protected LevelType type;

    public LevelType Type
    {
        get { return type; }
    }

    protected float timer;
    protected int currentScore;
    protected int totalMoves; 

    protected bool didWin;

    // Use this for initialization
    void Start()
    {
        hud.SetScore(currentScore);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        timer += Time.deltaTime;
    }

    public virtual void GameWin()
    {
        grid.GameOver();
        didWin = true;
        StartCoroutine(WaitForGridFill());
    }

    public virtual void GameLose()
    {
        grid.GameOver();
        didWin = false;
        StartCoroutine(WaitForGridFill());
    }

    public virtual void OnMove()
    {

    }

    public virtual void OnPieceCleared(GamePiece piece)
    {
        currentScore += piece.score;
        hud.SetScore(currentScore);
    }

    protected virtual IEnumerator WaitForGridFill()
    {
        while (grid.IsFilling)
        {
            yield return 0;
        }

        if (didWin)
        {
            hud.OnGameWin(currentScore, timer, totalMoves);
        }
        else
        {
            hud.OnGameLose();
        }
    }
}
