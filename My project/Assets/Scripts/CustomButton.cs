using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

public class CustomButton : MonoBehaviour, IPointerDownHandler
{
    public UnityEvent EventOnPointerDown;

    public void OnPointerDown(PointerEventData eventData)
    {
        EventOnPointerDown.Invoke();
    }
}