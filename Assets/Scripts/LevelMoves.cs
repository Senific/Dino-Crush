using UnityEngine;
using System.Collections;

public class LevelMoves : Level
{

    public int numMoves;
    public int targetScore;

    private int movesUsed = 0;

    // Use this for initialization
    void Start()
    {
        type = LevelType.MOVES;

        hud.SetLevelID(levelID);
        hud.SetLevelType(type); 
        hud.SetScore(currentScore); 
     //   hud.SetMovesRemaining(numMoves);
    }

    

    public override void OnMove()
    {
        movesUsed++;

      //  hud.SetMovesRemaining(numMoves - movesUsed);

        if (numMoves - movesUsed == 0)
        {
            if (currentScore >= targetScore)
            {
                GameWin();
            }
            else
            {
                GameLose();
            }
        }
    }
}
