using System.Collections;
using UnityEngine;

public class CheckActive : MonoBehaviour
{
    private bool isActive;
    private bool setOff;

    private void Awake()
    {
        isActive = false;
        setOff = false;
    }

    private void Update()
    {
        if (setOff)
        {
            StartCoroutine(turnOff());
        }
    }

    private IEnumerator turnOff()
    {
        setOff = false;

        yield return new WaitForSeconds(0.5f);

        isActive = false;
    }

    public void setActive()
    {
        isActive = true;
        setOff = true;
    }

    public bool getActive()
    {
        return isActive;
    }
}
