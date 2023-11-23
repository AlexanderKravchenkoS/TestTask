using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollbarSwitcher : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private ScrollRect scrollRect;

    public void OnPointerEnter(PointerEventData eventData) => scrollRect.enabled = true;

    public void OnPointerExit(PointerEventData eventData) => scrollRect.enabled = false;
}