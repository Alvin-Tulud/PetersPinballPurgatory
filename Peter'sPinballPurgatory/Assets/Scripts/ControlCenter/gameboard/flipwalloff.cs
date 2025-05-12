using UnityEngine;

public class flipwalloff : MonoBehaviour
{
    public GameObject launchwall;

    private bool wallOn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resetwall();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            launchwall.SetActive(true);

            other.gameObject.GetComponent<MoveCharacter>().setCap(true);
        }
    }

    public bool getwallPassed()
    {
        return wallOn = launchwall.activeSelf;
    }

    public void resetwall()
    {
        launchwall.SetActive(false);
    }
}
