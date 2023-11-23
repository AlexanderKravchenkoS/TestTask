using DG.Tweening;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class AlienCreationSystem : MonoBehaviour
{
    [SerializeField]
    private Transform playground;

    private Recources recources;

    private Action<AlienType> OnRecreateAlienButton;
    private InputService inputService;

    public void Init(Recources recources, Action<AlienType> createButton, InputService inputService)
    {
        this.recources = recources;
        OnRecreateAlienButton = createButton;
        this.inputService = inputService;
    }

    public void CreateAlien(AlienData alienData)
    {
        var alien = Instantiate(recources.AlienPrefab, playground);
        alien.Init(alienData, PlaceAlien);
        inputService.SetTarget(alien);
    }

    private void PlaceAlien(Alien alien)
    {
        PlaygroundCell cell = RaycastCell(alien);
        if (cell != null)
        {
            cell.PlaceAlien(alien);
        }
        else
        {
            OnRecreateAlienButton(alien.Data.Type);
            Destroy(alien.gameObject);
        }
    }

    private PlaygroundCell RaycastCell(Alien alien)
    {
        var hits = Physics.RaycastAll(alien.transform.position, Vector3.forward, 10f);
        foreach (var hit in hits)
        {
            if (hit.transform.TryGetComponent(out PlaygroundCell cell))
            {
                return hit.transform.GetComponent<PlaygroundCell>();
            }
        }
        return null;
    }
}
