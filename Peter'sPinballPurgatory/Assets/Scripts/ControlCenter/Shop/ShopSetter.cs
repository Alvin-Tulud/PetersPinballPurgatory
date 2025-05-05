using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopSetter : MonoBehaviour
{
    public List<GameObject> AllShopItems;
    private List<GameObject> ItemsForSale;

    public GameObject Shop;
    public Transform ShopSlot;

    private void Awake()
    {
        ItemsForSale = new List<GameObject>();
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
        ItemsForSale.Clear();

        Shop.SetActive(true);
        //randomly spawn 3 items

        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < AllShopItems.Count; j++)
            {
                if (i + 1 <= 3 && j + 1 < AllShopItems.Count)
                {
                    int rand = Random.Range(0, 101);

                    AllShopItems = AllShopItems.OrderBy(x => Random.value).ToList();

                    if (rand < AllShopItems[j].GetComponent<Rarity>().getRarity())
                    {
                        GameObject g = Instantiate(AllShopItems[j]);
                        g.transform.SetParent(ShopSlot.transform, false);

                        Debug.Log(g.name);

                        ItemsForSale.Add(g);

                        break;
                    }
                }
                else
                {
                    GameObject g = Instantiate(AllShopItems[j]);
                    g.transform.SetParent(ShopSlot.transform, false);

                    Debug.Log(g.name);

                    ItemsForSale.Add(g);

                    break;
                }
            }
        }
    }
}
