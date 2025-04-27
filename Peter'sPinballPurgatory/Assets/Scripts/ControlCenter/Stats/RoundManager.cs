using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    private int roundNum;
    private float minBumperScore;
    private static float BumperScoreIncrease = 0.2f;
    private bool roundPassed;
    private int timesScorePassed;

    public Vector3 playerinitPos;
    public GameObject playerPrefab;

    public killPlayer[] killBoxes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        roundNum = 0;
        minBumperScore = 1;

        setBumpers();
        //Debug.Log("setbumpers");
    }

    // Update is called once per frame
    void Update()
    {
        foreach(killPlayer player in killBoxes)
        {
            if (player.getState())
            {
                player.setState();

                if (GetComponent<ScoreTracker>().checkPass())
                {
                    Debug.Log("round increase");
                    increaseRound();
                }

                resetBoardState();
            }
        }
    }

    public void resetBoardState()
    {
        Instantiate(playerPrefab, playerinitPos, Quaternion.Euler(90f, 270f, 180f));

        Camera.main.GetComponent<CameraFollow>().setPlayerPos();

        GameObject.Find("launchwalltrigger").GetComponent<flipwalloff>().resetwall();

        GetComponent<ScoreTracker>().resetScore();

        setBumpers();
    }

    public void increaseRound()
    {
        roundNum++;
        minBumperScore += BumperScoreIncrease;
    }

    public void setBumpers()
    {
        List<int> bumperScores = new List<int>();

        int maxScore = 0;

        for (int i = 0; i < 7; i++)
        {
            if (i >= 6)
            {
                bumperScores.Add(Mathf.FloorToInt(minBumperScore) * 4);
            }
            else if (i >= 4)
            {
                bumperScores.Add(Mathf.FloorToInt(minBumperScore) * 3);
            }
            else if (i >= 2)
            {
                bumperScores.Add(Mathf.FloorToInt(minBumperScore) * 2);
            }
            else
            {
                bumperScores.Add(Mathf.FloorToInt(minBumperScore));
            }
            maxScore += bumperScores[i];

            //Debug.Log("score:" + bumperScores[i]);
        }

        setScore( Mathf.FloorToInt( (maxScore / 2) * (1 + (roundNum * 0.1f) ) ) );


        bumperScores = bumperScores.OrderBy(x => Random.value).ToList();

        GetComponent<BumperSetter>().setBumpers(bumperScores);
    }

    public void setScore(int score)
    {
        GetComponent<ScoreTracker>().SetMaxScore(score);
        GetComponent<ScoreTracker>().resetScore();
    }
}
