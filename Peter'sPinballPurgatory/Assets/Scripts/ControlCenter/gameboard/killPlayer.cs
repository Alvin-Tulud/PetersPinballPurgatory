using UnityEngine;

public class killPlayer : MonoBehaviour
{
    private bool killedPlayer = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);

            killedPlayer = true;
        }
    }

    public bool getState()
    {
        return killedPlayer;
    }

    public void setState()
    {
        killedPlayer = false;
    }
}
