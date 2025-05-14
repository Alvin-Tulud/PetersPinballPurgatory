using System.Collections;
using UnityEngine;

public class Mitosis : QuarterAbstract
{
    private RoundStatTracker stats;
    private int checkedTime;

    public GameObject fakePeter;

    private AudioSource sfx;

    private void Awake()
    {
        stats = FindAnyObjectByType<RoundStatTracker>();
        checkedTime = 0;

        sfx = GetComponent<AudioSource>();
    }

    private void Update()
    {
        checkTrigger();
    }

    public override void checkTrigger()
    {
        // ✅ Only run if item is active
        if (!GetComponent<CheckActive>().getActive()) return;

        int timecheck = Mathf.FloorToInt(stats.getTime());

        if (timecheck != checkedTime && timecheck % 3 == 0 && stats.getTime() > 2f && FindAnyObjectByType<flipwalloff>().getwallPassed())
        {
            Debug.Log("Check trigger Mitosis");

            checkedTime = timecheck;

            doEffect();
        }

        if (!FindAnyObjectByType<flipwalloff>().getwallPassed())
        {
            checkedTime = 0;
        }
    }

    public override void doEffect()
    {
        // ✅ Only play SFX when active
        if (sfx != null)
        {
            sfx.Play();
        }

        Debug.Log("Check effect Mitosis");

        GetComponent<CheckActive>().setActive();

        if (GameObject.FindWithTag("Player"))
        {
            GameObject player = GameObject.FindWithTag("Player");

            if (fakePeter != null)
            {
                Instantiate(fakePeter, player.transform.position, player.transform.rotation);
            }
        }
    }
}
