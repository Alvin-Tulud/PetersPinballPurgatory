using UnityEngine;

public class getcollhit : MonoBehaviour
{
    private bool canhit;

    public bool getCanHit()
    {
        return canhit;
    }

    public void setCanHit(bool canhit)
    {
        this.canhit = canhit;
    }
}
