using UnityEngine;

public abstract class QuarterAbstract : MonoBehaviour
{
    public enum triggertype
    {
        bumpcount,
        timed,
        onbumperhit,
        dies,
        firsthit,
        goalmet,
        hithighestfirst,
    }

    public enum raritytype
    {
        common,
        uncommon,
        rare,
    }

    public int count;
    public triggertype trigger;
    public raritytype rarity;
    public RoundStatTracker stats;

    //if trigger has been met call doEffect
    public void checkTrigger()
    {
        if (trigger == triggertype.bumpcount)
        {

        }
        else if (trigger == triggertype.timed)
        {

        }
        else if (trigger == triggertype.onbumperhit)
        {

        }
        else if (trigger == triggertype.dies)
        {

        }
        else if (trigger == triggertype.firsthit)
        {

        }
        else if (trigger == triggertype.goalmet)
        {

        }
        else if (trigger == triggertype.hithighestfirst)
        {

        }
    }

    //when triggered do effect
    public abstract void doEffect();

    public int getRarity()
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
