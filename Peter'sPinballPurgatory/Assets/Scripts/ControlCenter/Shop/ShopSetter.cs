using System.Collections.Generic;
using UnityEngine;

public class ShopSetter : MonoBehaviour
{
    public List<GameObject> AllShopItems;
    private List<GameObject> ItemsForSale;

    public GameObject Shop;
    public List<Transform> ShopSlots;

    private bool selectedItem;

    private void Awake()
    {
        
    }
}
