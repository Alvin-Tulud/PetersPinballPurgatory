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

    public void exitShop(GameObject selected)
    {
        //close shop and delete the other 2 objects not selected
        ItemsForSale.Remove(selected);

        foreach(var item in ItemsForSale)
        {
            Destroy(item.gameObject);
        }

        Shop.SetActive(false);

        //let roundmanager know shopping is done
        GetComponent<RoundManager>().resetBoardState();
    }

    public void enterShop()
    {
        Shop.SetActive(true);

        //randomly spawn 3 items
    }
}
