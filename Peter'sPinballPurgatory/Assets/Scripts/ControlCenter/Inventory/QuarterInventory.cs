using System.Collections.Generic;
using UnityEngine;

public class QuarterInventory : MonoBehaviour
{
    private List<GameObject> Quarters;
    public GameObject InventoryDisplay;

    private void Start()
    {
        Quarters = new List<GameObject>();
    }

    public void addQuarter(GameObject Quarter)
    {
        Quarters.Add(Quarter);
        Quarter.transform.SetParent(InventoryDisplay.transform, false);
    }

    public List<GameObject> getQuarters()
    {
        return Quarters;
    }
}
