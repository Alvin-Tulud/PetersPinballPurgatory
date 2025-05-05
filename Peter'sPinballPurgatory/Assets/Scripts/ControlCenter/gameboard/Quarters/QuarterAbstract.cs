using UnityEngine;

public abstract class QuarterAbstract : MonoBehaviour
{
    //if trigger has been met call doEffect
    public abstract void checkTrigger();

    //when triggered do effect
    public abstract void doEffect();

}
