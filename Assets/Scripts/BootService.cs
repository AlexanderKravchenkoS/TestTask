using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BootService : MonoBehaviour
{
    [SerializeField] 
    private List<AlienType> StartInventory;
    [SerializeField]
    private ScrollRect ScrollForButtons;
    [SerializeField]
    private Recources Recources;
    [SerializeField]
    private AlienCreationSystem AlienCreationSystem;
    [SerializeField]
    private InputService InputService;

    private void Start()
    {
        InitAlienCreationSystem();
        FillInventory();
    }

    private void InitAlienCreationSystem() => AlienCreationSystem.Init(Recources, CreateButton, InputService);

    private void FillInventory()
    {
        foreach (var item in StartInventory)
        {
            CreateButton(item);
        }
    }

    private void CreateButton(AlienType item)
    {
        CreateAlienButton createAlien = Instantiate(Recources.CreateAlienButton, ScrollForButtons.content);
        createAlien.Init(Recources.GetAlienData(item), AlienCreationSystem.CreateAlien);
    }
}
