using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour
{
    private int roundNum;
    private float minBumperScore;
    private static float BumperScoreIncrease = 0.2f;
    private bool roundPassed;
    private int timesScorePassed;

    public UnityEngine.Vector3 playerinitPos;
    public GameObject playerPrefab;

    public TextMeshProUGUI roundText;

    public killPlayer[] killBoxes;

    public int maxlives;
    private int currentlives;

    public TextMeshProUGUI livesText;

    private bool canCheckRoundOver;

    public TextMeshProUGUI timeText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;

        roundNum = 0;
        minBumperScore = 1;

        setBumpers();
        setRound();
        //Debug.Log("setbumpers");
        currentlives = maxlives;

        setLives();

        canCheckRoundOver = true;
    }

    // Update is called once per frame
    void Update()
    {
        checkRoundOver();
        setTime();
    }

    private void checkRoundOver()
    {
        bool playerdead = false;

        foreach (killPlayer player in killBoxes)
        {
            if (player.getState())
            {
                GetComponent<RoundStatTracker>().setDead();

                playerdead = true;
            }
        }

        List<GameObject> quarter = GetComponent<QuarterInventory>().getQuarters();

        bool quartersActive = false;

        foreach (GameObject g in quarter)
        {
            if (g.GetComponent<CheckActive>().getActive())
            {
                quartersActive = true;
            }
        }

        if (canCheckRoundOver)
        {
            StartCoroutine(waitcheckRoundOver(quartersActive, playerdead));
        }
    }

    IEnumerator waitcheckRoundOver(bool quartersActive, bool playerdead)
    {
        //Debug.Log("checking over: " + quartersActive + " " + playerdead);

        canCheckRoundOver = false;

        yield return new WaitForSeconds(0.5f);

        if (!quartersActive && playerdead && !GameObject.FindWithTag("Player") && !GameObject.FindWithTag("FakePlayer"))
        {
            Debug.Log("round over");

            foreach (killPlayer player in killBoxes)
            {
                player.setState();
            }

            GetComponent<RoundStatTracker>().setRoundOver();

            currentlives--;

            setLives();

            if (GetComponent<ScoreTracker>().checkPass())
            {
                Debug.Log("round increase");
                increaseRound();
            }
            else
            {
                resetBoardState();
            }

            if (currentlives <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }

        canCheckRoundOver = true;
    }

    public void resetBoardState()
    {
        Instantiate(playerPrefab, playerinitPos, UnityEngine.Quaternion.Euler(90f, 270f, 180f));

        Camera.main.GetComponent<CameraFollow>().setPlayerPos();

        GameObject.Find("launchwalltrigger").GetComponent<flipwalloff>().resetwall();

        GetComponent<ScoreTracker>().resetScore();

        GetComponent<RoundStatTracker>().resetStats();

        setBumpers();
    }

    private void increaseRound()
    {
        roundNum++;
        minBumperScore += BumperScoreIncrease;

        currentlives = maxlives;
        setLives();

        setRound();

        GetComponent<ShopSetter>().enterShop();
    }

    public void setBumpers()
    {
        List<BigInteger> bumperScores = new List<BigInteger>();

        BigInteger maxScore = 0;

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

        if (roundNum == 0)
        {
            setScore(8);
        }
        else
        {
            setScore(Mathf.FloorToInt(Mathf.Pow(((float)maxScore) / 4, (roundNum * 0.2f)) + (((float)maxScore) / 2) * (1 + (roundNum * 0.4f))));
        }


        bumperScores = bumperScores.OrderBy(x => Random.value).ToList();

        GetComponent<BumperSetter>().setBumpers(bumperScores);
    }

    public void setScore(int score)
    {
        GetComponent<ScoreTracker>().SetMaxScore(score);
        GetComponent<ScoreTracker>().resetScore();
    }

    private void setRound()
    {
        roundText.text = "Round:\n" + (roundNum + 1);
    }

    private void setLives()
    {
        livesText.text = "Lives:\n" + currentlives;
    }

    private void setTime()
    {
        if (FindAnyObjectByType<flipwalloff>().getwallPassed() && !GetComponent<RoundStatTracker>().isDead())
        {
            timeText.text = "Time:\n" + GetComponent<RoundStatTracker>().getTime().ToString("F2");
        }
        else
        {
            timeText.text = "Time:\n0.00";
        }
        
    }

    public int getRound()
    {
        return roundNum;
    }
}
