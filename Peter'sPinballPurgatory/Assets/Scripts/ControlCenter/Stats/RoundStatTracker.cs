using System;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class RoundStatTracker : MonoBehaviour
{
    private long bumps;
    private bool died, firsthit, firsthithighest;
    private float seconds;
    private int deathCount;

    private BigInteger highestbumper;
    private bool hasLaunched;
    private bool roundOver;
    private bool canResetTime;
    private bool canJumble;
    private bool hasJumbled;

    public Button jumbleButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resetStats();
    }

    private void Update()
    {
        if (roundOver)
        {
            //Debug.Log("it actually flips roundOver");
        }

        setStartTime();
    }

    public void resetStats()
    {
        bumps = 0;
        died = false;
        firsthit = false;
        firsthithighest = false;
        deathCount = 0;

        roundOver = false;

        canResetTime = true;
        canJumble = true;
        hasJumbled = false;

        jumbleButton.interactable = true;
    }

    public void setHighestBumper()
    {
        BumperStats[] stats = FindObjectsByType<BumperStats>(FindObjectsSortMode.None);

        BigInteger highest = 0;
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

    public void setStartTime()
    {
        if (canResetTime && FindAnyObjectByType<flipwalloff>().getwallPassed())
        {
            seconds = Time.unscaledTime;

            seconds = (float)Math.Round(seconds, 2, MidpointRounding.ToEven);

            canResetTime = false;
        }
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

    public float getTime()
    {
        return (float)Math.Round(Time.unscaledTime, 2, MidpointRounding.ToEven) - seconds;
    }

    public void setDead()
    {
        died = true;
        deathCount = FindAnyObjectByType<killPlayer>().getDeathCount();
    }

    public long getBumps()
    {
        return bumps;
    }

    public bool isDead()
    {
        return died;
    }

    public int getDeathCount()
    {
        return deathCount;
    }

    public void setRoundOver()
    {
        roundOver = true;
    }

    public bool isRoundOver()
    {
        return roundOver;
    }

    public int getRound()
    {
        return GetComponent<RoundManager>().getRound();
    }

    public bool getHasLaunched()
    {
        if (FindAnyObjectByType<MoveCharacter>())
        {
            return FindAnyObjectByType<MoveCharacter>().getHasLaunched();
        }

        return false;
    }

    public void jumbleBumpers()
    {
        if (canJumble)
        {
            canJumble = false;

            jumbleButton.interactable = false;

            hasJumbled = true;

            GetComponent<RoundManager>().setBumpers();
        }
    }
}
