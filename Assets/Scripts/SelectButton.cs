using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectButton : MonoBehaviour, IPointerMoveHandler, IPointerDownHandler, IPointerUpHandler
{
    private Action OnDrag;
    private bool clicked;

    public void Init(Action onDrag) => OnDrag = onDrag;

    public void OnPointerDown(PointerEventData eventData) => clicked = true;
    public void OnPointerUp(PointerEventData eventData) => clicked = false;

    public void OnPointerMove(PointerEventData eventData)
    {
        if (!clicked) return;
        if (eventData.delta.normalized.y >= 0.5f)
        {
            OnDrag();
        }
    }
}
