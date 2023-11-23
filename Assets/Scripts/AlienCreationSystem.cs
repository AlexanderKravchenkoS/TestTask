using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AlienCreationSystem : MonoBehaviour
{
    [SerializeField]
    private Canvas PlaygroundCanvas;

    private Recources recources;

    private Action<AlienType> OnRecreateAlienButton;

    private const float PlaceDuration = 0.7f;

    public void Init(Recources recources, Action<AlienType> createButton)
    {
        this.recources = recources;
        OnRecreateAlienButton = createButton;
    }

    public void CreateAlien(AlienData alienData)
    {
        var alien = Instantiate(recources.AlienPrefab, PlaygroundCanvas.transform);
        alien.Init(alienData, PlaceAlien);
    }

    private void PlaceAlien(Alien alien)
    {
        PlaygroundCell cell = RaycastCell(alien);
        if (cell != null)
        {
            float scale = alien.GetComponent<RectTransform>().sizeDelta.x / cell.GetComponent<RectTransform>().sizeDelta.x;
            alien.enabled = false;

            Sequence sequence = DOTween.Sequence();
            sequence.Append(alien.transform.DOMove(cell.transform.position, PlaceDuration));
            sequence.Append(alien.transform.DOScale(scale, PlaceDuration));
            sequence.AppendCallback(() =>
                {
                    cell.PlaceAlien(alien.Data);
                    Destroy(alien.gameObject);
                });
        }
        else
        {
            OnRecreateAlienButton(alien.Data.Type);
            Destroy(alien.gameObject);
        }
    }

    private PlaygroundCell RaycastCell(Alien alien)
    {
        PointerEventData data = new PointerEventData(EventSystem.current);
        data.position = alien.transform.position;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(data, results);
        foreach (RaycastResult result in results)
        {
            if (result.gameObject.TryGetComponent(out PlaygroundCell cell))
            {
                return cell;
            }
        }
        return null;
    }
}
