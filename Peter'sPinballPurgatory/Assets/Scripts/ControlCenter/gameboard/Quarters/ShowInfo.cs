using UnityEngine;
using UnityEngine.EventSystems;

public class ShowInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Pointer entered UI element: " + gameObject.name);
        // Add code here to execute when the mouse enters the UI element
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Pointer clicked UI element: " + gameObject.name);
        // Add code here to execute when the mouse enters the UI element
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Pointer exited UI element: " + gameObject.name);
        // Add code here to execute when the mouse exits the UI element
    }
}
