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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetStats()
    {
        bumps = 0;
        died = false;
        firsthit = false;
        firsthithighest = false;
        seconds = 0;
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
}
