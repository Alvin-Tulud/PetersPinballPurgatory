using UnityEngine;

public class DoubleTrouble : QuarterAbstract
{
    public int count;
    public raritytype rarity;
    private RoundStatTracker stats;
    private bool doOnce;

    private int lastBumpsCount;

    private void Awake()
    {
        stats = FindAnyObjectByType<RoundStatTracker>();

        doOnce = true;
        lastBumpsCount = 0;
    }

    private void Update()
    {
        checkTrigger();
    }

    public override void checkTrigger()
    {
        if (doOnce && lastBumpsCount < stats.getBumps())
        {
            doEffect();
        }
    }

    public override void doEffect()
    {
        
    }

    public override int getRarity()
    {
        if (rarity == raritytype.common)
        {
            return 70;
        }
        else if (rarity == raritytype.uncommon)
        {
            return 20;
        }
        else
        {
            return 10;
        }
    }
}
