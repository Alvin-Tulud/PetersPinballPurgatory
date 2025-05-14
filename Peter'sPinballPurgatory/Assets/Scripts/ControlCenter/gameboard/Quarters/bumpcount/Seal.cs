using UnityEngine;

public class Seal : QuarterAbstract
{
    private RoundStatTracker stats;
    private int bumps;

    private AudioSource sfx;

    private void Awake()
    {
        stats = FindAnyObjectByType<RoundStatTracker>();
        sfx = GetComponent<AudioSource>();

        bumps = 0;
    }

    private void Update()
    {
        checkTrigger();
    }

    public override void checkTrigger()
    {
        if (stats.getHasLaunched() && bumps < stats.getBumps())
        {
            bumps++;

            if (bumps % 5 == 0 && bumps > 1)
            {
                Debug.Log("do trigger seal: " + bumps);

                doEffect();
            }
        }

        if (stats.isRoundOver() || stats.getBumps() == 0)
        {
            bumps = 0;
        }
    }

    public override void doEffect()
    {
        Debug.Log("do effect seal: " + bumps);

        // Play SFX if available
        if (sfx != null)
        {
            sfx.Play();
        }

        GetComponent<CheckActive>().setActive();

        swivelpaddle[] paddle = FindObjectsByType<swivelpaddle>(FindObjectsSortMode.None);

        int rand = Random.Range(0, 2);

        paddle[rand].setStartSwing(true);
    }
}
