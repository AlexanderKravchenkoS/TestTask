using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AlienCreationSystem : MonoBehaviour
{
    [SerializeField]
    private Canvas PlaygroundCanvas;

    private Recources recources;

    public void Init(Recources recources)
    {
        this.recources = recources;
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
            cell.PlaceAlien(alien.Data);
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
