using UnityEngine;

public class killPlayer : MonoBehaviour
{
    private bool killedPlayer = false;
    private int deathCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            deathCount++;

            Destroy(other.gameObject);

            killedPlayer = true;
        }

        if (other.gameObject.CompareTag("FakePlayer"))
        {
            deathCount++;

            Destroy(other.gameObject);
        }
    }

    public int getDeathCount()
    {
        return deathCount;
    }

    public bool getState()
    {
        return killedPlayer;
    }

    public void setState()
    {
        killedPlayer = false;
        deathCount = 0;
    }
}
