using UnityEngine;
using System.Collections;

public class LevelTimer : Level
{

    public int timeInSeconds;
    public int targetScore;


    private bool timeOut = false;

    // Use this for initialization
    void Start()
    {
        type = LevelType.TIMER;

        hud.SetLevelType(type);
        hud.SetScore(currentScore);
        hud.SetTimeRemaining(timeInSeconds);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if (!timeOut)
        {
            hud.SetTimeRemaining((int)Mathf.Max(timeInSeconds - timer));

            if (timeInSeconds - timer <= 0)
            {
                if (currentScore >= targetScore)
                {
                    GameWin();
                }
                else
                {
                    GameLose();
                }

                timeOut = true;
            }
        }
    }
}
