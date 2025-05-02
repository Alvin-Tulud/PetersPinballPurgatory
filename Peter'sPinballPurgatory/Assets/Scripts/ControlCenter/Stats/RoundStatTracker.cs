using System;
using System.Collections.Generic;
using UnityEngine;

public class RoundStatTracker : MonoBehaviour
{
    private int bumps;
    private bool died, firsthit, firsthithighest;
    private float seconds;

    private int highestbumper;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resetStats();
    }

    public void resetStats()
    {
        bumps = 0;
        died = false;
        firsthit = false;
        firsthithighest = false;
        seconds = Time.unscaledTime;

        seconds = (float) Math.Round(seconds, 2, MidpointRounding.ToEven);
    }

    public void setHighestBumper()
    {
        BumperStats[] stats = FindObjectsByType<BumperStats>(FindObjectsSortMode.None);

        int highest = 0;
        highestbumper = highest;

        foreach(BumperStats stat in stats)
        {
            if (stat.getScore() > highest)
            {
                highest = stat.getScore();
            }
        }

        highestbumper = highest;
    }

    public void AddBump()
    {
        if (!firsthit)
        {
            firsthit = true;

            if (GetComponent<ScoreTracker>().getScore() == highestbumper)
            {
                firsthithighest = true;
            }
        }

        bumps++;
    }

    public void setDead()
    {
        died = true;
    }

    public int getBumps()
    {
        return bumps;
    }

    public bool isDead()
    {
        return died;
    }

    public int getRound()
    {
        return GetComponent<RoundManager>().getRound();
    }
}
