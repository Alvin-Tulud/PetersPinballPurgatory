using System.Collections.Generic;
using UnityEngine;

public class QuarterInventory : MonoBehaviour
{
    public List<GameObject> Quarters;
    public GameObject InventoryDisplay;

    public void addQuarter(GameObject Quarter)
    {
        Quarters.Add(Quarter);
    }
}
