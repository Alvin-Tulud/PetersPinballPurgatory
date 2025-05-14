using System.Collections;
using UnityEngine;

public class CheckActive : MonoBehaviour
{
    private bool isActive;
    private bool setOff;

    private Light activeLight;

    private void Awake()
    {
        isActive = false;
        setOff = false;

        activeLight = GetComponent<Light>();
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
        activeLight.enabled = true;

        setOff = false;

        yield return new WaitForSeconds(0.5f);

        isActive = false;

        activeLight.enabled = false;
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
