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
        Debug.Log("Pointer entered UI element: " + gameObject.name);
        // Add code here to execute when the mouse enters the UI element
        Info.SetActive(true);
        Info.GetComponent<Canvas>().sortingOrder = 2;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Pointer clicked UI element: " + gameObject.name);
        // Add code here to execute when the mouse enters the UI element
        canSelect = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Pointer exited UI element: " + gameObject.name);
        // Add code here to execute when the mouse exits the UI element
        Info.GetComponent<Canvas>().sortingOrder = 1;
        Info.SetActive(false);
    }

    public bool GetCanSelect()
    {
        return canSelect;
    }
}
