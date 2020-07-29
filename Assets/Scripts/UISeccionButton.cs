using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UISeccionButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public UnityEvent onPointerClickEvent;
    public UnityEvent onPointerEnterEvent;
    public UnityEvent onPointerExitEvent;

    public void OnPointerClick(PointerEventData eventData)
    {
        onPointerClickEvent.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        onPointerEnterEvent.Invoke();
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        onPointerExitEvent.Invoke();
    }
} 