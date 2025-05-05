using UnityEngine;
using UnityEngine.EventSystems;

public class ShowInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject Info;
    private bool canSelect;

    private void Awake()
    {
        Info.SetActive(false);
        canSelect = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("hovering: " + gameObject.name);

        Info.SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clicked: " + gameObject.name);
        //add code here to send it to inventory list and object
        if (canSelect)
        {
            QuarterInventory inventory = FindAnyObjectByType<QuarterInventory>();

            inventory.addQuarter(this.gameObject);

            ShopSetter shop = FindAnyObjectByType<ShopSetter>();

            shop.exitShop(this.gameObject);

            canSelect = false;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Info.SetActive(false);
    }

    public bool GetCanSelect()
    {
        return canSelect;
    }
}
