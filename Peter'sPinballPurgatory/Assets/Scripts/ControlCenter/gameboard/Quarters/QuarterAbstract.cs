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
        bouncecount,
        hitlowest,
        hithighest,
        hitwalltwice,
        hitwall,
    }

    public int count;
    public triggertype trigger;
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
        else if (trigger == triggertype.bouncecount)
        {

        }
        else if (trigger == triggertype.hitlowest)
        {

        }
        else if (trigger == triggertype.hithighest)
        {

        }
        else if (trigger == triggertype.hitwalltwice)
        {

        }
        else if (trigger == triggertype.hitwall)
        {

        }
    }

    //when triggered do effect
    public abstract void doEffect();
}
