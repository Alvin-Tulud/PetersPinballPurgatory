using UnityEngine;

public class flipwalloff : MonoBehaviour
{
    public GameObject launchwall;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        launchwall.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            launchwall.SetActive(true);

            other.gameObject.GetComponent<MoveCharacter>().setCap(true);
        }
    }
}
