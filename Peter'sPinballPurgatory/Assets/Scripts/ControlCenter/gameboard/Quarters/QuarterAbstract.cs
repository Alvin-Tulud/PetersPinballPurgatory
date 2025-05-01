using UnityEngine;

public abstract class QuarterAbstract : MonoBehaviour
{
    public enum raritytype
    {
        common,
        uncommon,
        rare,
    }

    //if trigger has been met call doEffect
    public abstract void checkTrigger();

    //when triggered do effect
    public abstract void doEffect();

    public abstract int getRarity();
}
